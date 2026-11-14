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
        placeholderLabel = new Label();
        SuspendLayout();
        //
        // placeholderLabel
        //
        placeholderLabel.Dock = DockStyle.Fill;
        placeholderLabel.Font = new Font("Segoe UI", 12F);
        placeholderLabel.ForeColor = Color.FromArgb(93, 105, 125);
        placeholderLabel.Name = "placeholderLabel";
        placeholderLabel.Text = "Đăng nhập (đang làm, #36)";
        placeholderLabel.TextAlign = ContentAlignment.MiddleCenter;
        //
        // LoginDialog
        //
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        ClientSize = new Size(420, 460);
        Controls.Add(placeholderLabel);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "LoginDialog";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Flashcards · Đăng nhập";
        ResumeLayout(false);
    }

    #endregion

    private Label placeholderLabel;
}
