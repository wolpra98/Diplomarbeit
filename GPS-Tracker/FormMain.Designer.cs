namespace GPS_Tracker
{
  partial class FormMain
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
      this.btnCenterMap = new System.Windows.Forms.Button();
      this.slider = new System.Windows.Forms.TrackBar();
      this.btnClear = new System.Windows.Forms.Button();
      this.btnImport = new System.Windows.Forms.Button();
      this.tabHigh = new System.Windows.Forms.TabPage();
      this.btnHigh = new System.Windows.Forms.Button();
      this.tabDataSelect = new System.Windows.Forms.TabPage();
      this.label4 = new System.Windows.Forms.Label();
      this.btnImportRoutes = new System.Windows.Forms.Button();
      this.lbxRoutes = new System.Windows.Forms.ListBox();
      this.label3 = new System.Windows.Forms.Label();
      this.cbxBaud = new System.Windows.Forms.ComboBox();
      this.btnConnect = new System.Windows.Forms.Button();
      this.cbxCOM = new System.Windows.Forms.ComboBox();
      this.btnRefresh = new System.Windows.Forms.Button();
      this.msCtrl = new System.Windows.Forms.MenuStrip();
      this.msRoute = new System.Windows.Forms.ToolStripMenuItem();
      this.miSave = new System.Windows.Forms.ToolStripMenuItem();
      this.miLoad = new System.Windows.Forms.ToolStripMenuItem();
      this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.msSettings = new System.Windows.Forms.ToolStripMenuItem();
      this.lblLoadData = new System.Windows.Forms.Label();
      this.panelHeightprofile = new GPS_Tracker.GraphPanel();
      this.lblTime = new System.Windows.Forms.Label();
      this.lblHeight = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.numLat)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numLng)).BeginInit();
      this.tabCtrl.SuspendLayout();
      this.tabMap.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
      this.tabHigh.SuspendLayout();
      this.tabDataSelect.SuspendLayout();
      this.msCtrl.SuspendLayout();
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
      this.gMap.Size = new System.Drawing.Size(650, 550);
      this.gMap.TabIndex = 0;
      this.gMap.Zoom = 16D;
      this.gMap.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.OnMapZoomChanged);
      // 
      // btnSetRoute
      // 
      this.btnSetRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSetRoute.Location = new System.Drawing.Point(697, 6);
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
      this.label1.Location = new System.Drawing.Point(697, 65);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(64, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Längengrad";
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(697, 110);
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
      this.numLat.Location = new System.Drawing.Point(697, 126);
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
      this.numLng.Location = new System.Drawing.Point(697, 81);
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
      this.tabCtrl.Controls.Add(this.tabDataSelect);
      this.tabCtrl.Location = new System.Drawing.Point(0, 27);
      this.tabCtrl.Name = "tabCtrl";
      this.tabCtrl.SelectedIndex = 0;
      this.tabCtrl.Size = new System.Drawing.Size(853, 576);
      this.tabCtrl.TabIndex = 8;
      this.tabCtrl.SelectedIndexChanged += new System.EventHandler(this.OnTabChange);
      // 
      // tabMap
      // 
      this.tabMap.Controls.Add(this.btnCenterMap);
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
      this.tabMap.Size = new System.Drawing.Size(845, 550);
      this.tabMap.TabIndex = 0;
      this.tabMap.Text = "Map";
      this.tabMap.UseVisualStyleBackColor = true;
      // 
      // btnCenterMap
      // 
      this.btnCenterMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCenterMap.Location = new System.Drawing.Point(697, 152);
      this.btnCenterMap.Name = "btnCenterMap";
      this.btnCenterMap.Size = new System.Drawing.Size(145, 50);
      this.btnCenterMap.TabIndex = 11;
      this.btnCenterMap.Text = "Center Map";
      this.btnCenterMap.UseVisualStyleBackColor = true;
      this.btnCenterMap.Click += new System.EventHandler(this.OnBtnCenterMapClick);
      // 
      // slider
      // 
      this.slider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.slider.LargeChange = 1;
      this.slider.Location = new System.Drawing.Point(646, 0);
      this.slider.Maximum = 20;
      this.slider.Minimum = 1;
      this.slider.Name = "slider";
      this.slider.Orientation = System.Windows.Forms.Orientation.Vertical;
      this.slider.Size = new System.Drawing.Size(45, 550);
      this.slider.TabIndex = 10;
      this.slider.TickStyle = System.Windows.Forms.TickStyle.Both;
      this.slider.Value = 16;
      this.slider.ValueChanged += new System.EventHandler(this.OnValueChanged);
      // 
      // btnClear
      // 
      this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClear.Location = new System.Drawing.Point(697, 208);
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
      this.btnImport.Location = new System.Drawing.Point(697, 264);
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
      this.tabHigh.Size = new System.Drawing.Size(845, 550);
      this.tabHigh.TabIndex = 1;
      this.tabHigh.Text = "Höhenprofil";
      this.tabHigh.UseVisualStyleBackColor = true;
      // 
      // btnHigh
      // 
      this.btnHigh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnHigh.Location = new System.Drawing.Point(697, 6);
      this.btnHigh.Name = "btnHigh";
      this.btnHigh.Size = new System.Drawing.Size(145, 50);
      this.btnHigh.TabIndex = 1;
      this.btnHigh.Text = "Höhe hinzufügen";
      this.btnHigh.UseVisualStyleBackColor = true;
      this.btnHigh.Click += new System.EventHandler(this.OnButtonHeightClick);
      // 
      // tabDataSelect
      // 
      this.tabDataSelect.Controls.Add(this.label4);
      this.tabDataSelect.Controls.Add(this.btnImportRoutes);
      this.tabDataSelect.Controls.Add(this.lbxRoutes);
      this.tabDataSelect.Controls.Add(this.label3);
      this.tabDataSelect.Controls.Add(this.cbxBaud);
      this.tabDataSelect.Controls.Add(this.btnConnect);
      this.tabDataSelect.Controls.Add(this.cbxCOM);
      this.tabDataSelect.Controls.Add(this.btnRefresh);
      this.tabDataSelect.Controls.Add(this.lblLoadData);
      this.tabDataSelect.Location = new System.Drawing.Point(4, 22);
      this.tabDataSelect.Name = "tabDataSelect";
      this.tabDataSelect.Padding = new System.Windows.Forms.Padding(3);
      this.tabDataSelect.Size = new System.Drawing.Size(845, 550);
      this.tabDataSelect.TabIndex = 2;
      this.tabDataSelect.Text = "Datenauswahl";
      this.tabDataSelect.UseVisualStyleBackColor = true;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(9, 8);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(156, 18);
      this.label4.TabIndex = 7;
      this.label4.Text = "Vorhandene Routen";
      // 
      // btnImportRoutes
      // 
      this.btnImportRoutes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnImportRoutes.Location = new System.Drawing.Point(6, 510);
      this.btnImportRoutes.Name = "btnImportRoutes";
      this.btnImportRoutes.Size = new System.Drawing.Size(165, 34);
      this.btnImportRoutes.TabIndex = 6;
      this.btnImportRoutes.Text = "Importiere Routen";
      this.btnImportRoutes.UseVisualStyleBackColor = true;
      this.btnImportRoutes.Click += new System.EventHandler(this.OnBtnImportRoutesClick);
      // 
      // lbxRoutes
      // 
      this.lbxRoutes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.lbxRoutes.FormattingEnabled = true;
      this.lbxRoutes.Location = new System.Drawing.Point(6, 32);
      this.lbxRoutes.Name = "lbxRoutes";
      this.lbxRoutes.Size = new System.Drawing.Size(165, 472);
      this.lbxRoutes.TabIndex = 5;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(541, 58);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(53, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Baudrate:";
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
      this.cbxBaud.Location = new System.Drawing.Point(600, 55);
      this.cbxBaud.Name = "cbxBaud";
      this.cbxBaud.Size = new System.Drawing.Size(121, 21);
      this.cbxBaud.TabIndex = 3;
      this.cbxBaud.SelectedIndexChanged += new System.EventHandler(this.OnBaudChanged);
      // 
      // btnConnect
      // 
      this.btnConnect.Location = new System.Drawing.Point(751, 16);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.Size = new System.Drawing.Size(75, 23);
      this.btnConnect.TabIndex = 2;
      this.btnConnect.Text = "Connect";
      this.btnConnect.UseVisualStyleBackColor = true;
      this.btnConnect.Click += new System.EventHandler(this.OnConnectClick);
      // 
      // cbxCOM
      // 
      this.cbxCOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxCOM.Location = new System.Drawing.Point(624, 18);
      this.cbxCOM.Name = "cbxCOM";
      this.cbxCOM.Size = new System.Drawing.Size(121, 21);
      this.cbxCOM.Sorted = true;
      this.cbxCOM.TabIndex = 1;
      // 
      // btnRefresh
      // 
      this.btnRefresh.Location = new System.Drawing.Point(541, 16);
      this.btnRefresh.Name = "btnRefresh";
      this.btnRefresh.Size = new System.Drawing.Size(75, 23);
      this.btnRefresh.TabIndex = 0;
      this.btnRefresh.Text = "Refresh";
      this.btnRefresh.UseVisualStyleBackColor = true;
      this.btnRefresh.Click += new System.EventHandler(this.OnRefreshClick);
      // 
      // msCtrl
      // 
      this.msCtrl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msRoute,
            this.msSettings});
      this.msCtrl.Location = new System.Drawing.Point(0, 0);
      this.msCtrl.Name = "msCtrl";
      this.msCtrl.Size = new System.Drawing.Size(853, 24);
      this.msCtrl.TabIndex = 9;
      this.msCtrl.Text = "msCtrl";
      // 
      // msRoute
      // 
      this.msRoute.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSave,
            this.miLoad,
            this.miDelete});
      this.msRoute.Name = "msRoute";
      this.msRoute.Size = new System.Drawing.Size(50, 20);
      this.msRoute.Text = "Route";
      // 
      // miSave
      // 
      this.miSave.Name = "miSave";
      this.miSave.Size = new System.Drawing.Size(126, 22);
      this.miSave.Text = "Speichern";
      // 
      // miLoad
      // 
      this.miLoad.Name = "miLoad";
      this.miLoad.Size = new System.Drawing.Size(126, 22);
      this.miLoad.Text = "Laden";
      // 
      // miDelete
      // 
      this.miDelete.Name = "miDelete";
      this.miDelete.Size = new System.Drawing.Size(126, 22);
      this.miDelete.Text = "Löschen";
      // 
      // msSettings
      // 
      this.msSettings.Name = "msSettings";
      this.msSettings.Size = new System.Drawing.Size(90, 20);
      this.msSettings.Text = "Einstellungen";
      // 
      // lblLoadData
      // 
      this.lblLoadData.BackColor = System.Drawing.Color.White;
      this.lblLoadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblLoadData.Location = new System.Drawing.Point(0, 0);
      this.lblLoadData.Name = "lblLoadData";
      this.lblLoadData.Size = new System.Drawing.Size(845, 547);
      this.lblLoadData.TabIndex = 9;
      this.lblLoadData.Text = "Lade Daten ...";
      this.lblLoadData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.lblLoadData.UseWaitCursor = true;
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
      this.panelHeightprofile.Size = new System.Drawing.Size(691, 550);
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
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(853, 601);
      this.Controls.Add(this.tabCtrl);
      this.Controls.Add(this.msCtrl);
      this.MainMenuStrip = this.msCtrl;
      this.Name = "FormMain";
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
      this.tabDataSelect.ResumeLayout(false);
      this.tabDataSelect.PerformLayout();
      this.msCtrl.ResumeLayout(false);
      this.msCtrl.PerformLayout();
      this.panelHeightprofile.ResumeLayout(false);
      this.panelHeightprofile.PerformLayout();
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
    private System.Windows.Forms.TabPage tabDataSelect;
    private System.Windows.Forms.Button btnConnect;
    private System.Windows.Forms.ComboBox cbxCOM;
    private System.Windows.Forms.Button btnRefresh;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox cbxBaud;
    private System.Windows.Forms.Button btnCenterMap;
    private System.Windows.Forms.MenuStrip msCtrl;
    private System.Windows.Forms.ToolStripMenuItem msRoute;
    private System.Windows.Forms.ToolStripMenuItem msSettings;
    private System.Windows.Forms.ToolStripMenuItem miSave;
    private System.Windows.Forms.ToolStripMenuItem miLoad;
    private System.Windows.Forms.ToolStripMenuItem miDelete;
    private System.Windows.Forms.ListBox lbxRoutes;
    private System.Windows.Forms.Button btnImportRoutes;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label lblLoadData;
  }
}

