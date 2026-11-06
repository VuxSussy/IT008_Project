namespace FlashcardsApp;

partial class OverviewScreen
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
        placeholderLabel.Name = "placeholderLabel";
        placeholderLabel.Text = "Tổng quan (đang làm)";
        placeholderLabel.TextAlign = ContentAlignment.MiddleCenter;
        //
        // OverviewScreen
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        Controls.Add(placeholderLabel);
        Name = "OverviewScreen";
        Size = new Size(900, 640);
        ResumeLayout(false);
    }

    #endregion

    private Label placeholderLabel;
}
