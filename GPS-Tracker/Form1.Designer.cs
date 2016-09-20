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
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.numLat = new System.Windows.Forms.NumericUpDown();
      this.numLng = new System.Windows.Forms.NumericUpDown();
      ((System.ComponentModel.ISupportInitialize)(this.numLat)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numLng)).BeginInit();
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
      this.gMap.MinZoom = 1;
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
      this.btnSetRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSetRoute.Location = new System.Drawing.Point(448, 12);
      this.btnSetRoute.Name = "btnSetRoute";
      this.btnSetRoute.Size = new System.Drawing.Size(133, 52);
      this.btnSetRoute.TabIndex = 1;
      this.btnSetRoute.Text = "Set Route";
      this.btnSetRoute.UseVisualStyleBackColor = true;
      this.btnSetRoute.Click += new System.EventHandler(this.OnBtnSetRouteClick);
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(449, 71);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(22, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Lat";
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(448, 130);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(25, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Lng";
      // 
      // numLat
      // 
      this.numLat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.numLat.DecimalPlaces = 6;
      this.numLat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.numLat.Location = new System.Drawing.Point(448, 87);
      this.numLat.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
      this.numLat.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
      this.numLat.Name = "numLat";
      this.numLat.Size = new System.Drawing.Size(133, 20);
      this.numLat.TabIndex = 6;
      this.numLat.Value = new decimal(new int[] {
            47092240,
            0,
            0,
            393216});
      // 
      // numLng
      // 
      this.numLng.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.numLng.DecimalPlaces = 6;
      this.numLng.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.numLng.Location = new System.Drawing.Point(448, 146);
      this.numLng.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
      this.numLng.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
      this.numLng.Name = "numLng";
      this.numLng.Size = new System.Drawing.Size(133, 20);
      this.numLng.TabIndex = 7;
      this.numLng.Value = new decimal(new int[] {
            15402685,
            0,
            0,
            393216});
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(593, 454);
      this.Controls.Add(this.numLng);
      this.Controls.Add(this.numLat);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnSetRoute);
      this.Controls.Add(this.gMap);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.OnFormLoad);
      ((System.ComponentModel.ISupportInitialize)(this.numLat)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numLng)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private GMap.NET.WindowsForms.GMapControl gMap;
    private System.Windows.Forms.Button btnSetRoute;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown numLat;
    private System.Windows.Forms.NumericUpDown numLng;
  }
}

