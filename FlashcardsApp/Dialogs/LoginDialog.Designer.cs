namespace FlashcardsApp;

partial class LoginDialog
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        brandPanel = new Panel();
        usernameTextBox = new TextBox();
        confirmPasswordLabel = new Label();
        passwordLabel = new Label();
        usernameLabel = new Label();
        exitButton = new Button();
        modeLinkLabel = new LinkLabel();
        errorLabel = new Label();
        confirmPasswordTextBox = new TextBox();
        loginButton = new Button();
        passwordTextBox = new TextBox();
        titleLabel = new Label();
        logoPanel = new LogoBox();
        brandLabel = new SpacedLabel();
        taglineLabel = new Label();
        brandPanel.SuspendLayout();
        SuspendLayout();
        // 
        // brandPanel
        // 
        brandPanel.Controls.Add(usernameTextBox);
        brandPanel.Controls.Add(confirmPasswordLabel);
        brandPanel.Controls.Add(passwordLabel);
        brandPanel.Controls.Add(usernameLabel);
        brandPanel.Controls.Add(exitButton);
        brandPanel.Controls.Add(modeLinkLabel);
        brandPanel.Controls.Add(errorLabel);
        brandPanel.Controls.Add(confirmPasswordTextBox);
        brandPanel.Controls.Add(loginButton);
        brandPanel.Controls.Add(passwordTextBox);
        brandPanel.Controls.Add(titleLabel);
        brandPanel.Controls.Add(logoPanel);
        brandPanel.Controls.Add(brandLabel);
        brandPanel.Controls.Add(taglineLabel);
        brandPanel.Dock = DockStyle.Fill;
        brandPanel.Location = new Point(0, 0);
        brandPanel.Margin = new Padding(0);
        brandPanel.Name = "brandPanel";
        brandPanel.Size = new Size(404, 421);
        brandPanel.TabIndex = 1;
        // 
        // usernameTextBox
        // 
        usernameTextBox.Cursor = Cursors.IBeam;
        usernameTextBox.ForeColor = SystemColors.WindowText;
        usernameTextBox.Location = new Point(40, 160);
        usernameTextBox.MaxLength = 20;
        usernameTextBox.Name = "usernameTextBox";
        usernameTextBox.Size = new Size(318, 25);
        usernameTextBox.TabIndex = 14;
        // 
        // confirmPasswordLabel
        // 
        confirmPasswordLabel.AutoSize = true;
        confirmPasswordLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        confirmPasswordLabel.Location = new Point(40, 243);
        confirmPasswordLabel.Name = "confirmPasswordLabel";
        confirmPasswordLabel.Size = new Size(131, 19);
        confirmPasswordLabel.TabIndex = 13;
        confirmPasswordLabel.Text = "Nhập lại mật khẩu";
        // 
        // passwordLabel
        // 
        passwordLabel.AutoSize = true;
        passwordLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        passwordLabel.Location = new Point(40, 193);
        passwordLabel.Name = "passwordLabel";
        passwordLabel.Size = new Size(71, 19);
        passwordLabel.TabIndex = 12;
        passwordLabel.Text = "Mật khẩu";
        // 
        // usernameLabel
        // 
        usernameLabel.AutoSize = true;
        usernameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        usernameLabel.Location = new Point(40, 138);
        usernameLabel.Name = "usernameLabel";
        usernameLabel.Size = new Size(107, 19);
        usernameLabel.TabIndex = 11;
        usernameLabel.Text = "Tên đăng nhập";
        // 
        // exitButton
        // 
        exitButton.FlatAppearance.BorderSize = 0;
        exitButton.FlatStyle = FlatStyle.Flat;
        exitButton.Font = new Font("Segoe UI", 10F, FontStyle.Underline);
        exitButton.Location = new Point(174, 374);
        exitButton.Name = "exitButton";
        exitButton.Size = new Size(64, 28);
        exitButton.TabIndex = 10;
        exitButton.Text = "Thoát";
        exitButton.UseVisualStyleBackColor = true;
        exitButton.Click += exitButton_Click;
        // 
        // modeLinkLabel
        // 
        modeLinkLabel.AutoSize = true;
        modeLinkLabel.Location = new Point(288, 380);
        modeLinkLabel.Name = "modeLinkLabel";
        modeLinkLabel.Size = new Size(101, 19);
        modeLinkLabel.TabIndex = 9;
        modeLinkLabel.TabStop = true;
        modeLinkLabel.Text = "modeLinkLabel";
        modeLinkLabel.LinkClicked += modeLinkLabel_LinkClicked;
        // 
        // errorLabel
        // 
        errorLabel.BackColor = Color.PeachPuff;
        errorLabel.BorderStyle = BorderStyle.FixedSingle;
        errorLabel.FlatStyle = FlatStyle.Flat;
        errorLabel.Font = new Font("Segoe UI", 10F);
        errorLabel.ForeColor = Color.OrangeRed;
        errorLabel.Location = new Point(40, 383);
        errorLabel.Name = "errorLabel";
        errorLabel.Size = new Size(73, 21);
        errorLabel.TabIndex = 8;
        errorLabel.Text = "errorLabel";
        // 
        // confirmPasswordTextBox
        // 
        confirmPasswordTextBox.Cursor = Cursors.IBeam;
        confirmPasswordTextBox.Location = new Point(40, 265);
        confirmPasswordTextBox.MaxLength = 50;
        confirmPasswordTextBox.Name = "confirmPasswordTextBox";
        confirmPasswordTextBox.PasswordChar = '•';
        confirmPasswordTextBox.Size = new Size(318, 25);
        confirmPasswordTextBox.TabIndex = 7;
        // 
        // loginButton
        // 
        loginButton.BackColor = Color.FromArgb(15, 122, 112);
        loginButton.Cursor = Cursors.Hand;
        loginButton.FlatAppearance.BorderSize = 0;
        loginButton.FlatStyle = FlatStyle.Flat;
        loginButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        loginButton.ForeColor = Color.White;
        loginButton.Location = new Point(40, 310);
        loginButton.Name = "loginButton";
        loginButton.Size = new Size(318, 38);
        loginButton.TabIndex = 6;
        loginButton.Text = "Đăng nhập";
        loginButton.UseVisualStyleBackColor = false;
        loginButton.Click += loginButton_Click;
        // 
        // passwordTextBox
        // 
        passwordTextBox.Cursor = Cursors.IBeam;
        passwordTextBox.Location = new Point(40, 215);
        passwordTextBox.MaxLength = 50;
        passwordTextBox.Name = "passwordTextBox";
        passwordTextBox.PasswordChar = '•';
        passwordTextBox.Size = new Size(318, 25);
        passwordTextBox.TabIndex = 5;
        // 
        // titleLabel
        // 
        titleLabel.AutoSize = true;
        titleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        titleLabel.Location = new Point(40, 80);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(153, 30);
        titleLabel.TabIndex = 3;
        titleLabel.Text = "Tạo tài khoản";
        // 
        // logoPanel
        // 
        logoPanel.Location = new Point(40, 26);
        logoPanel.Name = "logoPanel";
        logoPanel.Size = new Size(34, 34);
        logoPanel.TabIndex = 0;
        // 
        // brandLabel
        // 
        brandLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        brandLabel.ForeColor = Color.FromArgb(15, 23, 42);
        brandLabel.Location = new Point(83, 26);
        brandLabel.Name = "brandLabel";
        brandLabel.Size = new Size(275, 20);
        brandLabel.TabIndex = 1;
        brandLabel.Text = "FLASHCARDS";
        brandLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // taglineLabel
        // 
        taglineLabel.Font = new Font("Segoe UI", 8.5F);
        taglineLabel.ForeColor = Color.FromArgb(51, 65, 85);
        taglineLabel.Location = new Point(79, 46);
        taglineLabel.Name = "taglineLabel";
        taglineLabel.Size = new Size(279, 23);
        taglineLabel.TabIndex = 2;
        taglineLabel.Text = "Học từng chút, nhớ thật lâu.";
        // 
        // LoginDialog
        // 
        AcceptButton = loginButton;
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.White;
        ClientSize = new Size(404, 421);
        Controls.Add(brandPanel);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "LoginDialog";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Flashcards · Đăng nhập";
        brandPanel.ResumeLayout(false);
        brandPanel.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Label placeholderLabel;
    private Panel brandPanel;
    private LogoBox logoPanel;
    private SpacedLabel brandLabel;
    private Label taglineLabel;
    private Label titleLabel;
    private TextBox passwordTextBox;
    private Button loginButton;
    private Label errorLabel;
    private TextBox confirmPasswordTextBox;
    private Label confirmPasswordLabel;
    private Label passwordLabel;
    private Label usernameLabel;
    private Button exitButton;
    private LinkLabel modeLinkLabel;
    private TextBox usernameTextBox;
    private TextBox textBox1;
}
