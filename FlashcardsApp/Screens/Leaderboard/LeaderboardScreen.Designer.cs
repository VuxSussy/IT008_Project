namespace FlashcardsApp;

partial class LeaderboardScreen
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
        placeholderLabel.Text = "Màn Bảng xếp hạng (đang làm, #45)";
        placeholderLabel.TextAlign = ContentAlignment.MiddleCenter;
        //
        // LeaderboardScreen
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(247, 249, 250);
        Controls.Add(placeholderLabel);
        Name = "LeaderboardScreen";
        Size = new Size(1040, 800);
        ResumeLayout(false);
    }

    #endregion

    private Label placeholderLabel;
}
