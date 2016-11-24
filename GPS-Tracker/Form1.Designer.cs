﻿namespace GPS_Tracker
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
      this.tabCtrl = new System.Windows.Forms.TabControl();
      this.tabMap = new System.Windows.Forms.TabPage();
      this.slider = new System.Windows.Forms.TrackBar();
      this.btnClear = new System.Windows.Forms.Button();
      this.btnImport = new System.Windows.Forms.Button();
      this.tabHigh = new System.Windows.Forms.TabPage();
      this.btnHigh = new System.Windows.Forms.Button();
      this.tabImport = new System.Windows.Forms.TabPage();
      this.btnRefresh = new System.Windows.Forms.Button();
      this.cbxCOM = new System.Windows.Forms.ComboBox();
      this.btnConnect = new System.Windows.Forms.Button();
      this.cbxBaud = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.panelHeightprofile = new GPS_Tracker.GraphPanel();
      this.lblTime = new System.Windows.Forms.Label();
      this.lblHeight = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.numLat)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numLng)).BeginInit();
      this.tabCtrl.SuspendLayout();
      this.tabMap.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
      this.tabHigh.SuspendLayout();
      this.tabImport.SuspendLayout();
      this.panelHeightprofile.SuspendLayout();
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
      this.gMap.Location = new System.Drawing.Point(0, 0);
      this.gMap.MarkersEnabled = true;
      this.gMap.MaxZoom = 20;
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
      this.gMap.Size = new System.Drawing.Size(652, 519);
      this.gMap.TabIndex = 0;
      this.gMap.Zoom = 16D;
      this.gMap.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.OnMapZoomChanged);
      // 
      // btnSetRoute
      // 
      this.btnSetRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSetRoute.Location = new System.Drawing.Point(699, 6);
      this.btnSetRoute.Name = "btnSetRoute";
      this.btnSetRoute.Size = new System.Drawing.Size(145, 50);
      this.btnSetRoute.TabIndex = 1;
      this.btnSetRoute.Text = "Set Route";
      this.btnSetRoute.UseVisualStyleBackColor = true;
      this.btnSetRoute.Click += new System.EventHandler(this.OnBtnSetRouteClick);
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(699, 65);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(64, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Längengrad";
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(699, 110);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(61, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Breitengrad";
      // 
      // numLat
      // 
      this.numLat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.numLat.DecimalPlaces = 6;
      this.numLat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.numLat.Increment = new decimal(new int[] {
            7,
            0,
            0,
            262144});
      this.numLat.Location = new System.Drawing.Point(699, 126);
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
      this.numLat.Size = new System.Drawing.Size(145, 20);
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
      this.numLng.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
      this.numLng.Location = new System.Drawing.Point(699, 81);
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
      this.numLng.Size = new System.Drawing.Size(145, 20);
      this.numLng.TabIndex = 7;
      this.numLng.Value = new decimal(new int[] {
            15402685,
            0,
            0,
            393216});
      // 
      // tabCtrl
      // 
      this.tabCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tabCtrl.Controls.Add(this.tabMap);
      this.tabCtrl.Controls.Add(this.tabHigh);
      this.tabCtrl.Controls.Add(this.tabImport);
      this.tabCtrl.Location = new System.Drawing.Point(0, 0);
      this.tabCtrl.Name = "tabCtrl";
      this.tabCtrl.SelectedIndex = 0;
      this.tabCtrl.Size = new System.Drawing.Size(855, 545);
      this.tabCtrl.TabIndex = 8;
      // 
      // tabMap
      // 
      this.tabMap.Controls.Add(this.slider);
      this.tabMap.Controls.Add(this.btnClear);
      this.tabMap.Controls.Add(this.btnImport);
      this.tabMap.Controls.Add(this.gMap);
      this.tabMap.Controls.Add(this.label2);
      this.tabMap.Controls.Add(this.numLng);
      this.tabMap.Controls.Add(this.btnSetRoute);
      this.tabMap.Controls.Add(this.numLat);
      this.tabMap.Controls.Add(this.label1);
      this.tabMap.Location = new System.Drawing.Point(4, 22);
      this.tabMap.Name = "tabMap";
      this.tabMap.Padding = new System.Windows.Forms.Padding(3);
      this.tabMap.Size = new System.Drawing.Size(847, 519);
      this.tabMap.TabIndex = 0;
      this.tabMap.Text = "Map";
      this.tabMap.UseVisualStyleBackColor = true;
      // 
      // slider
      // 
      this.slider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.slider.LargeChange = 1;
      this.slider.Location = new System.Drawing.Point(648, 0);
      this.slider.Maximum = 20;
      this.slider.Minimum = 1;
      this.slider.Name = "slider";
      this.slider.Orientation = System.Windows.Forms.Orientation.Vertical;
      this.slider.Size = new System.Drawing.Size(45, 519);
      this.slider.TabIndex = 10;
      this.slider.TickStyle = System.Windows.Forms.TickStyle.Both;
      this.slider.Value = 16;
      this.slider.ValueChanged += new System.EventHandler(this.OnValueChanged);
      // 
      // btnClear
      // 
      this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClear.Location = new System.Drawing.Point(699, 208);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(145, 50);
      this.btnClear.TabIndex = 9;
      this.btnClear.Text = "Clear Route";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.OnBtnClearClick);
      // 
      // btnImport
      // 
      this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnImport.Location = new System.Drawing.Point(699, 152);
      this.btnImport.Name = "btnImport";
      this.btnImport.Size = new System.Drawing.Size(145, 50);
      this.btnImport.TabIndex = 8;
      this.btnImport.Text = "Import Route";
      this.btnImport.UseVisualStyleBackColor = true;
      this.btnImport.Click += new System.EventHandler(this.OnBtnImportClick);
      // 
      // tabHigh
      // 
      this.tabHigh.Controls.Add(this.btnHigh);
      this.tabHigh.Controls.Add(this.panelHeightprofile);
      this.tabHigh.Location = new System.Drawing.Point(4, 22);
      this.tabHigh.Name = "tabHigh";
      this.tabHigh.Padding = new System.Windows.Forms.Padding(3);
      this.tabHigh.Size = new System.Drawing.Size(847, 519);
      this.tabHigh.TabIndex = 1;
      this.tabHigh.Text = "Höhenprofil";
      this.tabHigh.UseVisualStyleBackColor = true;
      // 
      // btnHigh
      // 
      this.btnHigh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnHigh.Location = new System.Drawing.Point(699, 6);
      this.btnHigh.Name = "btnHigh";
      this.btnHigh.Size = new System.Drawing.Size(145, 50);
      this.btnHigh.TabIndex = 1;
      this.btnHigh.Text = "Höhe hinzufügen";
      this.btnHigh.UseVisualStyleBackColor = true;
      this.btnHigh.Click += new System.EventHandler(this.OnButtonHeightClick);
      // 
      // tabImport
      // 
      this.tabImport.Controls.Add(this.label3);
      this.tabImport.Controls.Add(this.cbxBaud);
      this.tabImport.Controls.Add(this.btnConnect);
      this.tabImport.Controls.Add(this.cbxCOM);
      this.tabImport.Controls.Add(this.btnRefresh);
      this.tabImport.Location = new System.Drawing.Point(4, 22);
      this.tabImport.Name = "tabImport";
      this.tabImport.Padding = new System.Windows.Forms.Padding(3);
      this.tabImport.Size = new System.Drawing.Size(847, 519);
      this.tabImport.TabIndex = 2;
      this.tabImport.Text = "Import";
      this.tabImport.UseVisualStyleBackColor = true;
      // 
      // btnRefresh
      // 
      this.btnRefresh.Location = new System.Drawing.Point(3, 6);
      this.btnRefresh.Name = "btnRefresh";
      this.btnRefresh.Size = new System.Drawing.Size(75, 23);
      this.btnRefresh.TabIndex = 0;
      this.btnRefresh.Text = "Refresh";
      this.btnRefresh.UseVisualStyleBackColor = true;
      this.btnRefresh.Click += new System.EventHandler(this.OnRefreshClick);
      // 
      // cbxCOM
      // 
      this.cbxCOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxCOM.Location = new System.Drawing.Point(86, 8);
      this.cbxCOM.Name = "cbxCOM";
      this.cbxCOM.Size = new System.Drawing.Size(121, 21);
      this.cbxCOM.Sorted = true;
      this.cbxCOM.TabIndex = 1;
      // 
      // btnConnect
      // 
      this.btnConnect.Location = new System.Drawing.Point(213, 6);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.Size = new System.Drawing.Size(75, 23);
      this.btnConnect.TabIndex = 2;
      this.btnConnect.Text = "Connect";
      this.btnConnect.UseVisualStyleBackColor = true;
      this.btnConnect.Click += new System.EventHandler(this.OnConnectClick);
      // 
      // cbxBaud
      // 
      this.cbxBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxBaud.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "56000",
            "57600",
            "115200",
            "128000",
            "256000"});
      this.cbxBaud.Location = new System.Drawing.Point(353, 8);
      this.cbxBaud.Name = "cbxBaud";
      this.cbxBaud.Size = new System.Drawing.Size(121, 21);
      this.cbxBaud.TabIndex = 3;
      this.cbxBaud.SelectedIndexChanged += new System.EventHandler(this.OnBaudChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(294, 11);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(53, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Baudrate:";
      // 
      // panelHeightprofile
      // 
      this.panelHeightprofile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panelHeightprofile.BackColor = System.Drawing.Color.Transparent;
      this.panelHeightprofile.Controls.Add(this.lblTime);
      this.panelHeightprofile.Controls.Add(this.lblHeight);
      this.panelHeightprofile.Location = new System.Drawing.Point(0, 0);
      this.panelHeightprofile.Name = "panelHeightprofile";
      this.panelHeightprofile.Size = new System.Drawing.Size(693, 519);
      this.panelHeightprofile.TabIndex = 0;
      this.panelHeightprofile.Paint += new System.Windows.Forms.PaintEventHandler(this.OnGraphPanelPaint);
      this.panelHeightprofile.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnGraphPanelMouseMove);
      // 
      // lblTime
      // 
      this.lblTime.AutoSize = true;
      this.lblTime.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblTime.ForeColor = System.Drawing.Color.Red;
      this.lblTime.Location = new System.Drawing.Point(346, 253);
      this.lblTime.Name = "lblTime";
      this.lblTime.Size = new System.Drawing.Size(0, 19);
      this.lblTime.TabIndex = 1;
      // 
      // lblHeight
      // 
      this.lblHeight.AutoSize = true;
      this.lblHeight.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblHeight.ForeColor = System.Drawing.Color.Red;
      this.lblHeight.Location = new System.Drawing.Point(437, 30);
      this.lblHeight.Name = "lblHeight";
      this.lblHeight.Size = new System.Drawing.Size(0, 19);
      this.lblHeight.TabIndex = 0;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(856, 543);
      this.Controls.Add(this.tabCtrl);
      this.Name = "Form1";
      this.Text = "GPS-Tracker";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
      this.Load += new System.EventHandler(this.OnFormLoad);
      ((System.ComponentModel.ISupportInitialize)(this.numLat)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numLng)).EndInit();
      this.tabCtrl.ResumeLayout(false);
      this.tabMap.ResumeLayout(false);
      this.tabMap.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
      this.tabHigh.ResumeLayout(false);
      this.tabImport.ResumeLayout(false);
      this.tabImport.PerformLayout();
      this.panelHeightprofile.ResumeLayout(false);
      this.panelHeightprofile.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private GMap.NET.WindowsForms.GMapControl gMap;
    private System.Windows.Forms.Button btnSetRoute;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown numLat;
    private System.Windows.Forms.NumericUpDown numLng;
    private System.Windows.Forms.TabControl tabCtrl;
    private System.Windows.Forms.TabPage tabMap;
    private System.Windows.Forms.TabPage tabHigh;
    private System.Windows.Forms.Button btnHigh;
    private GraphPanel panelHeightprofile;
    private System.Windows.Forms.Label lblTime;
    private System.Windows.Forms.Label lblHeight;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.Button btnImport;
    private System.Windows.Forms.TrackBar slider;
    private System.Windows.Forms.TabPage tabImport;
    private System.Windows.Forms.Button btnConnect;
    private System.Windows.Forms.ComboBox cbxCOM;
    private System.Windows.Forms.Button btnRefresh;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox cbxBaud;
  }
}

