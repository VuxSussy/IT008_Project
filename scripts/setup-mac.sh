#!/bin/bash
# macOS Bash 3.2 compatible. Default mode checks only; no Git mutations.
set -euo pipefail

usage() {
    cat <<'HELP'
Usage: bash scripts/setup-mac.sh [options]
  --install                   Install missing Git using existing Homebrew,
                              and missing .NET 10 via Microsoft's per-user script
  --cross-build               Restore/build Windows target; cannot run UI/Designer
  --project PATH              Existing .csproj (relative paths are repository-relative)
  --help                      Show help
No database is needed (the app creates its own SQLite file). No Windows VM or paid software is installed.
HELP
}

fail() { printf 'ERROR: %s\n' "$*" >&2; exit 1; }
need_value() { [ "$#" -ge 2 ] && [ -n "$2" ] || fail "Missing value for $1"; }
install=0
cross_build=0
project_arg=''
download_dir=''
while [ "$#" -gt 0 ]; do
    case "$1" in
        --install) install=1; shift ;;
        --cross-build) cross_build=1; shift ;;
        --project) need_value "$@"; project_arg=$2; shift 2 ;;
        --help|-h) usage; exit 0 ;;
        *) fail "Unknown option: $1" ;;
    esac
done

[ "$(uname -s)" = Darwin ] || fail 'This script supports macOS only. Run setup-windows.ps1 inside Windows.'
if [ "$(sysctl -in sysctl.proc_translated 2>/dev/null || true)" = 1 ]; then
    fail 'Rosetta shell detected. Open a native Apple Silicon terminal (or arch -arm64 /bin/bash) and rerun.'
fi
case "$(uname -m)" in
    arm64) architecture=arm64 ;;
    x86_64) architecture=x64 ;;
    *) fail 'Only Intel and Apple Silicon Macs are covered.' ;;
esac
repo_root=$(CDPATH= cd -- "$(dirname -- "$0")/.." && pwd)
export DOTNET_CLI_UI_LANGUAGE=en
printf 'macOS %s. WinForms UI/Designer must run inside Windows.\n' "$architecture"

git_works() {
    command -v git >/dev/null 2>&1 || return 1
    if [ "$(command -v git)" = /usr/bin/git ]; then
        xcode-select -p >/dev/null 2>&1 || return 1
    fi
    git --version >/dev/null 2>&1
}
install_brew_tool() {
    command -v brew >/dev/null 2>&1 || fail 'Homebrew is missing. Follow manual installation in docs/02-cai-dat.md; Homebrew itself is never installed automatically.'
    brew install "$1"
}
if ! git_works; then
    if [ "$install" = 1 ]; then install_brew_tool git
    else fail 'Git is unavailable. Install Apple Command Line Tools or Git, or rerun with --install if Homebrew is installed.'; fi
fi
git_works || fail 'Git still cannot run; reopen Terminal after installation and rerun.'
git --version

has_sdk10() {
    command -v dotnet >/dev/null 2>&1 || return 1
    local sdk_list
    sdk_list=$(dotnet --list-sdks) || return 1
    printf '%s\n' "$sdk_list" | LC_ALL=C grep -Eq '^10\.0\.[0-9]+[[:space:]]+\['
}
sdk_dir="$HOME/.local/share/it008/dotnet"
if ! has_sdk10 && [ -x "$sdk_dir/dotnet" ]; then
    export DOTNET_ROOT="$sdk_dir"
    export PATH="$sdk_dir:$PATH"
fi
cleanup() {
    if [ -n "$download_dir" ]; then
        rm -f -- "$download_dir/dotnet-install.sh"
        rmdir "$download_dir" 2>/dev/null || true
    fi
}
trap cleanup EXIT
if ! has_sdk10; then
    [ "$install" = 1 ] || fail 'Stable .NET 10 SDK is missing. Install the Microsoft SDK package or rerun with --install.'
    command -v curl >/dev/null 2>&1 || fail 'curl is required to download the Microsoft installer.'
    download_dir=$(mktemp -d "${TMPDIR:-/tmp}/it008-setup.XXXXXX")
    curl --fail --location --proto '=https' --tlsv1.2 --retry 2 --connect-timeout 15 --max-time 120 \
        https://dot.net/v1/dotnet-install.sh -o "$download_dir/dotnet-install.sh"
    /bin/bash "$download_dir/dotnet-install.sh" --channel 10.0 --quality GA \
        --architecture "$architecture" --install-dir "$sdk_dir" --no-path
    export DOTNET_ROOT="$sdk_dir"
    export PATH="$sdk_dir:$PATH"
fi
has_sdk10 || fail 'Installation did not provide a stable .NET 10 SDK.'
dotnet --list-sdks
if [ "${DOTNET_ROOT:-}" = "$sdk_dir" ]; then
    printf 'Per-user SDK selected for this script. To use it in a new terminal, set:\n'
    printf '  export DOTNET_ROOT=%q\n  export PATH=%q:"$PATH"\n' "$sdk_dir" "$sdk_dir"
fi

if [ -z "$project_arg" ]; then project="$repo_root/FlashcardsApp/FlashcardsApp.csproj"
elif [[ "$project_arg" = /* ]]; then project=$project_arg
else project="$repo_root/$project_arg"; fi
if [ ! -f "$project" ]; then
    [ "$cross_build" = 0 ] || fail 'Project source is absent. Use --project with existing source; no source is pulled or cloned automatically.'
    printf 'Project source is absent at the expected path. Tools-only check; build not attempted.\n'
elif [ "$cross_build" = 1 ]; then
    LC_ALL=C grep -Eq '<TargetFramework>[[:space:]]*net10\.0-windows[[:space:]]*</TargetFramework>' "$project" \
        || fail 'Expected the repository project targeting net10.0-windows.'
    (
        cd "$repo_root"
        dotnet restore "$project" -p:EnableWindowsTargeting=true
        dotnet build "$project" --no-restore -p:EnableWindowsTargeting=true
    )
    printf 'Cross-build passed. It does NOT verify Windows runtime, Designer, SAPI or SQLite data.\n'
else
    printf 'Build not requested. Use --cross-build for compile-only checks.\n'
fi
printf 'Checks completed. No shell profile, Git state, data file or firewall was changed.\n'
