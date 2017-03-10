namespace GPS_Tracker
{
  partial class FormImport
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.lblText = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // lblText
      // 
      this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblText.Location = new System.Drawing.Point(12, 9);
      this.lblText.Name = "lblText";
      this.lblText.Size = new System.Drawing.Size(260, 111);
      this.lblText.TabIndex = 0;
      this.lblText.Text = "...";
      this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.lblText.UseWaitCursor = true;
      // 
      // FormImport
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 129);
      this.ControlBox = false;
      this.Controls.Add(this.lblText);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "FormImport";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.UseWaitCursor = true;
      this.Shown += new System.EventHandler(this.OnFormImportShown);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblText;
  }
}