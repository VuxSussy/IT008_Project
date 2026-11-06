namespace FlashcardsApp;

partial class FolderScreen
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
        placeholderLabel.Text = "Thư mục và từ vựng (đang làm)";
        placeholderLabel.TextAlign = ContentAlignment.MiddleCenter;
        //
        // FolderScreen
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        Controls.Add(placeholderLabel);
        Name = "FolderScreen";
        Size = new Size(900, 640);
        ResumeLayout(false);
    }

    #endregion

    private Label placeholderLabel;
}
