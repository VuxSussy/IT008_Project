namespace FlashcardsApp;

partial class ChallengeScreen
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

    #region Component Designer generated code

    private void InitializeComponent()
    {
        placeholderLabel = new Label();
        SuspendLayout();
        //
        // placeholderLabel
        //
        placeholderLabel.Dock = DockStyle.Fill;
        placeholderLabel.Font = new Font("Segoe UI", 14F);
        placeholderLabel.ForeColor = Color.FromArgb(93, 105, 125);
        placeholderLabel.Name = "placeholderLabel";
        placeholderLabel.Text = "Màn Thử thách hằng ngày (đang làm, #15)";
        placeholderLabel.TextAlign = ContentAlignment.MiddleCenter;
        //
        // ChallengeScreen
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(247, 249, 250);
        Controls.Add(placeholderLabel);
        Name = "ChallengeScreen";
        Size = new Size(1040, 800);
        ResumeLayout(false);
    }

    #endregion

    private Label placeholderLabel;
}
