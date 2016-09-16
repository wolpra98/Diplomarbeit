namespace GPS_Tracker
{
  partial class Form1
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.gMap = new GMap.NET.WindowsForms.GMapControl();
      this.btnSetRoute = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // gMap
      // 
      this.gMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gMap.Bearing = 0F;
      this.gMap.CanDragMap = true;
      this.gMap.EmptyTileColor = System.Drawing.Color.White;
      this.gMap.GrayScaleMode = false;
      this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
      this.gMap.LevelsKeepInMemmory = 5;
      this.gMap.Location = new System.Drawing.Point(12, 12);
      this.gMap.MarkersEnabled = true;
      this.gMap.MaxZoom = 18;
      this.gMap.MinZoom = 0;
      this.gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
      this.gMap.Name = "gMap";
      this.gMap.NegativeMode = false;
      this.gMap.PolygonsEnabled = true;
      this.gMap.RetryLoadTile = 0;
      this.gMap.RoutesEnabled = true;
      this.gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
      this.gMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
      this.gMap.ShowTileGridLines = false;
      this.gMap.Size = new System.Drawing.Size(430, 430);
      this.gMap.TabIndex = 0;
      this.gMap.Zoom = 16D;
      // 
      // btnSetRoute
      // 
      this.btnSetRoute.Location = new System.Drawing.Point(448, 12);
      this.btnSetRoute.Name = "btnSetRoute";
      this.btnSetRoute.Size = new System.Drawing.Size(133, 52);
      this.btnSetRoute.TabIndex = 1;
      this.btnSetRoute.Text = "Set Route";
      this.btnSetRoute.UseVisualStyleBackColor = true;
      this.btnSetRoute.Click += new System.EventHandler(this.OnBtnSetRouteClick);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(593, 454);
      this.Controls.Add(this.btnSetRoute);
      this.Controls.Add(this.gMap);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.OnFormLoad);
      this.ResumeLayout(false);

    }

    #endregion

    private GMap.NET.WindowsForms.GMapControl gMap;
    private System.Windows.Forms.Button btnSetRoute;
  }
}

