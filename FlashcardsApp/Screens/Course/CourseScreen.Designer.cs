namespace FlashcardsApp;

partial class CourseScreen
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
        placeholderLabel.Text = "Màn Khóa học (đang làm, #39)";
        placeholderLabel.TextAlign = ContentAlignment.MiddleCenter;
        //
        // CourseScreen
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(247, 249, 250);
        Controls.Add(placeholderLabel);
        Name = "CourseScreen";
        Size = new Size(1040, 800);
        ResumeLayout(false);
    }

    #endregion

    private Label placeholderLabel;
}
