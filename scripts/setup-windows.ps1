#requires -Version 5.1
<#
.SYNOPSIS
Checks Windows development prerequisites; installs/builds only with explicit switches.
.EXAMPLE
powershell -NoProfile -ExecutionPolicy Bypass -File scripts/setup-windows.ps1
.EXAMPLE
powershell -NoProfile -ExecutionPolicy Bypass -File scripts/setup-windows.ps1 -Install -Build
#>
[CmdletBinding()]
param(
    [switch]$Install,
    [switch]$Build,
    [switch]$RequireDesigner,
    [string]$ProjectPath
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'
$env:DOTNET_CLI_UI_LANGUAGE = 'en'

function Invoke-Checked {
    param([string]$Command, [string[]]$Arguments)
    & $Command @Arguments
    if ($LASTEXITCODE -ne 0) {
        throw "$Command failed (exit $LASTEXITCODE). Fix the error above and rerun."
    }
}

function Refresh-ProcessPath {
    $machinePath = [Environment]::GetEnvironmentVariable('Path', 'Machine')
    $userPath = [Environment]::GetEnvironmentVariable('Path', 'User')
    $env:Path = "$machinePath;$userPath;$env:Path"
}

function Install-WingetPackage {
    param([string]$Id, [string]$Architecture, [switch]$Interactive)
    if (-not (Get-Command winget -ErrorAction SilentlyContinue)) {
        throw 'WinGet is missing. Install/update App Installer from Microsoft, or install prerequisites manually (docs/02-cai-dat.md).'
    }
    $packageArguments = @('install', '--id', $Id, '--exact', '--source', 'winget',
        '--accept-source-agreements', '--accept-package-agreements')
    if ($Architecture) { $packageArguments += @('--architecture', $Architecture) }
    if ($Interactive) { $packageArguments += '--interactive' }
    Invoke-Checked -Command winget -Arguments $packageArguments
    Refresh-ProcessPath
}

function Test-Sdk10 {
    if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) { return $false }
    $sdks = @(& dotnet --list-sdks)
    if ($LASTEXITCODE -ne 0) { return $false }
    return @($sdks | Where-Object { $_ -match '^10\.0\.\d+\s+\[' }).Count -gt 0
}

try {
    if ($env:OS -ne 'Windows_NT') { throw 'Run this script inside Windows, including a Windows VM; use setup-mac.sh on macOS.' }
    $processor = Get-CimInstance Win32_Processor | Select-Object -First 1
    $architecture = switch ([int]$processor.Architecture) {
        9 { 'x64' }
        12 { 'arm64' }
        default { throw 'Only Windows x64 and ARM64 are covered by this project setup.' }
    }
    Write-Host "Windows $architecture; SDK target: .NET 10; database: SQLite file created by the app (nothing to install)."

    if (-not (Get-Command git -ErrorAction SilentlyContinue)) {
        if ($Install) { Install-WingetPackage -Id 'Git.Git' }
        else { throw 'Git is missing. Rerun with -Install or install Git for Windows manually.' }
    }
    Invoke-Checked -Command git -Arguments @('--version')
    if (-not (Test-Sdk10)) {
        if ($Install) { Install-WingetPackage -Id 'Microsoft.DotNet.SDK.10' -Architecture $architecture }
        else { throw 'Stable .NET 10 SDK is missing (a runtime or preview SDK is insufficient). Rerun with -Install.' }
    }
    if (-not (Test-Sdk10)) { throw '.NET 10 SDK still cannot be found. Reopen PowerShell after installation and rerun.' }
    Invoke-Checked -Command dotnet -Arguments @('--list-sdks')

    $hasDesigner = $false
    $programFilesX86 = [Environment]::GetFolderPath('ProgramFilesX86')
    $vswhere = Join-Path $programFilesX86 'Microsoft Visual Studio\Installer\vswhere.exe'
    if (Test-Path -LiteralPath $vswhere) {
        $designerPaths = @(& $vswhere -products '*' -version '[18.0,)' -requires Microsoft.VisualStudio.Workload.ManagedDesktop -property installationPath)
        $hasDesigner = $LASTEXITCODE -eq 0 -and $designerPaths.Count -gt 0
    }
    if (-not $hasDesigner) {
        if ($RequireDesigner) { throw 'Visual Studio 2026+ with .NET desktop development was not detected. Install that workload and rerun.' }
        Write-Warning 'CLI prerequisites are checked; WinForms Designer is not verified. Install Visual Studio 2026+ and .NET desktop development for visual editing.'
    }

    $repoRoot = Split-Path -Parent $PSScriptRoot
    if (-not $ProjectPath) { $ProjectPath = Join-Path $repoRoot 'FlashcardsApp\FlashcardsApp.csproj' }
    elseif (-not [IO.Path]::IsPathRooted($ProjectPath)) { $ProjectPath = Join-Path $repoRoot $ProjectPath }
    if (-not (Test-Path -LiteralPath $ProjectPath -PathType Leaf)) {
        if ($Build) { throw 'Project file is absent in this checkout. Supply -ProjectPath to existing source; this script never pulls or clones code.' }
        Write-Warning 'Project source is absent at the expected path; build was not attempted. Tools-only check completed.'
    }
    elseif ($Build) {
        [xml]$projectXml = Get-Content -LiteralPath $ProjectPath -Raw
        $frameworks = @($projectXml.SelectNodes('//TargetFramework') | ForEach-Object { $_.InnerText })
        if ($frameworks -notcontains 'net10.0-windows') { throw 'Expected the repository WinForms project targeting net10.0-windows.' }
        Push-Location $repoRoot
        try {
            Invoke-Checked -Command dotnet -Arguments @('restore', $ProjectPath)
            Invoke-Checked -Command dotnet -Arguments @('build', $ProjectPath, '--no-restore')
        }
        finally { Pop-Location }
        Write-Host 'Windows build passed. UI, SAPI and SQLite data still need runtime tests (press F5).'
    }
    else { Write-Host 'Build not requested. Use -Build to restore NuGet packages and build the existing project.' }
    Write-Host 'Checks completed. No Git configuration, commit, pull, push, firewall or data file was changed.'
    exit 0
}
catch {
    Write-Error $_ -ErrorAction Continue
    exit 1
}
