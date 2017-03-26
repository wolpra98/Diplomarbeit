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
      this.tabCtrl = new System.Windows.Forms.TabControl();
      this.tabMap = new System.Windows.Forms.TabPage();
      this.gbStatistic = new System.Windows.Forms.GroupBox();
      this.lblDistance = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.lblHeightAbs = new System.Windows.Forms.Label();
      this.lblHeightDif = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.lblRealDistance = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.btnCenterMap = new System.Windows.Forms.Button();
      this.slider = new System.Windows.Forms.TrackBar();
      this.tabHigh = new System.Windows.Forms.TabPage();
      this.panelHeightprofile = new GPS_Tracker.GraphPanel();
      this.lblTime = new System.Windows.Forms.Label();
      this.lblHeight = new System.Windows.Forms.Label();
      this.tabDataSelect = new System.Windows.Forms.TabPage();
      this.lblMaxDay = new System.Windows.Forms.Label();
      this.lblMinDay = new System.Windows.Forms.Label();
      this.DtpMax = new System.Windows.Forms.DateTimePicker();
      this.DtpMin = new System.Windows.Forms.DateTimePicker();
      this.label4 = new System.Windows.Forms.Label();
      this.btnImportRoutes = new System.Windows.Forms.Button();
      this.lbxRoutes = new System.Windows.Forms.ListBox();
      this.lblLoadData = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.tabCtrl.SuspendLayout();
      this.tabMap.SuspendLayout();
      this.gbStatistic.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
      this.tabHigh.SuspendLayout();
      this.panelHeightprofile.SuspendLayout();
      this.tabDataSelect.SuspendLayout();
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
      this.gMap.Size = new System.Drawing.Size(500, 500);
      this.gMap.TabIndex = 0;
      this.gMap.Zoom = 16D;
      this.gMap.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.OnMapZoomChanged);
      this.gMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMapMouseMove);
      // 
      // tabCtrl
      // 
      this.tabCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tabCtrl.Controls.Add(this.tabMap);
      this.tabCtrl.Controls.Add(this.tabHigh);
      this.tabCtrl.Controls.Add(this.tabDataSelect);
      this.tabCtrl.Location = new System.Drawing.Point(0, 0);
      this.tabCtrl.Name = "tabCtrl";
      this.tabCtrl.SelectedIndex = 0;
      this.tabCtrl.Size = new System.Drawing.Size(703, 526);
      this.tabCtrl.TabIndex = 8;
      this.tabCtrl.SelectedIndexChanged += new System.EventHandler(this.OnTabChange);
      // 
      // tabMap
      // 
      this.tabMap.Controls.Add(this.gbStatistic);
      this.tabMap.Controls.Add(this.btnCenterMap);
      this.tabMap.Controls.Add(this.slider);
      this.tabMap.Controls.Add(this.gMap);
      this.tabMap.Location = new System.Drawing.Point(4, 22);
      this.tabMap.Name = "tabMap";
      this.tabMap.Padding = new System.Windows.Forms.Padding(3);
      this.tabMap.Size = new System.Drawing.Size(695, 500);
      this.tabMap.TabIndex = 0;
      this.tabMap.Text = "Map";
      this.tabMap.UseVisualStyleBackColor = true;
      // 
      // gbStatistic
      // 
      this.gbStatistic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.gbStatistic.Controls.Add(this.lblDistance);
      this.gbStatistic.Controls.Add(this.label6);
      this.gbStatistic.Controls.Add(this.label5);
      this.gbStatistic.Controls.Add(this.lblHeightAbs);
      this.gbStatistic.Controls.Add(this.lblHeightDif);
      this.gbStatistic.Controls.Add(this.label2);
      this.gbStatistic.Controls.Add(this.lblRealDistance);
      this.gbStatistic.Controls.Add(this.label1);
      this.gbStatistic.Location = new System.Drawing.Point(545, 6);
      this.gbStatistic.Name = "gbStatistic";
      this.gbStatistic.Size = new System.Drawing.Size(147, 99);
      this.gbStatistic.TabIndex = 16;
      this.gbStatistic.TabStop = false;
      this.gbStatistic.Text = "Statistik:";
      // 
      // lblDistance
      // 
      this.lblDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblDistance.Location = new System.Drawing.Point(47, 20);
      this.lblDistance.Name = "lblDistance";
      this.lblDistance.Size = new System.Drawing.Size(100, 13);
      this.lblDistance.TabIndex = 14;
      this.lblDistance.Text = "0 m";
      this.lblDistance.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label6
      // 
      this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(2, 80);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(68, 13);
      this.label6.TabIndex = 17;
      this.label6.Text = "Höhenmeter:";
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(2, 60);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(82, 13);
      this.label5.TabIndex = 16;
      this.label5.Text = "Höhendifferenz:";
      // 
      // lblHeightAbs
      // 
      this.lblHeightAbs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblHeightAbs.Location = new System.Drawing.Point(69, 80);
      this.lblHeightAbs.Name = "lblHeightAbs";
      this.lblHeightAbs.Size = new System.Drawing.Size(78, 13);
      this.lblHeightAbs.TabIndex = 19;
      this.lblHeightAbs.Text = "0 m";
      this.lblHeightAbs.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // lblHeightDif
      // 
      this.lblHeightDif.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblHeightDif.Location = new System.Drawing.Point(69, 60);
      this.lblHeightDif.Name = "lblHeightDif";
      this.lblHeightDif.Size = new System.Drawing.Size(78, 13);
      this.lblHeightDif.TabIndex = 18;
      this.lblHeightDif.Text = "0 m";
      this.lblHeightDif.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(2, 40);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(78, 13);
      this.label2.TabIndex = 13;
      this.label2.Text = "Reale Strecke:";
      // 
      // lblRealDistance
      // 
      this.lblRealDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblRealDistance.Location = new System.Drawing.Point(69, 40);
      this.lblRealDistance.Name = "lblRealDistance";
      this.lblRealDistance.Size = new System.Drawing.Size(78, 13);
      this.lblRealDistance.TabIndex = 15;
      this.lblRealDistance.Text = "0 m";
      this.lblRealDistance.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(2, 20);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(47, 13);
      this.label1.TabIndex = 12;
      this.label1.Text = "Strecke:";
      // 
      // btnCenterMap
      // 
      this.btnCenterMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCenterMap.FlatAppearance.BorderSize = 0;
      this.btnCenterMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnCenterMap.Location = new System.Drawing.Point(545, 111);
      this.btnCenterMap.Name = "btnCenterMap";
      this.btnCenterMap.Size = new System.Drawing.Size(147, 58);
      this.btnCenterMap.TabIndex = 11;
      this.btnCenterMap.Text = "Route zentrieren";
      this.btnCenterMap.Click += new System.EventHandler(this.OnBtnCenterMapClick);
      // 
      // slider
      // 
      this.slider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.slider.LargeChange = 1;
      this.slider.Location = new System.Drawing.Point(496, 0);
      this.slider.Maximum = 20;
      this.slider.Minimum = 1;
      this.slider.Name = "slider";
      this.slider.Orientation = System.Windows.Forms.Orientation.Vertical;
      this.slider.Size = new System.Drawing.Size(45, 500);
      this.slider.TabIndex = 10;
      this.slider.TickStyle = System.Windows.Forms.TickStyle.Both;
      this.slider.Value = 16;
      this.slider.ValueChanged += new System.EventHandler(this.OnValueChanged);
      // 
      // tabHigh
      // 
      this.tabHigh.Controls.Add(this.panelHeightprofile);
      this.tabHigh.Location = new System.Drawing.Point(4, 22);
      this.tabHigh.Name = "tabHigh";
      this.tabHigh.Padding = new System.Windows.Forms.Padding(3);
      this.tabHigh.Size = new System.Drawing.Size(695, 500);
      this.tabHigh.TabIndex = 1;
      this.tabHigh.Text = "Höhenprofil";
      this.tabHigh.UseVisualStyleBackColor = true;
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
      this.panelHeightprofile.Size = new System.Drawing.Size(541, 500);
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
      // tabDataSelect
      // 
      this.tabDataSelect.Controls.Add(this.label3);
      this.tabDataSelect.Controls.Add(this.lblMaxDay);
      this.tabDataSelect.Controls.Add(this.lblMinDay);
      this.tabDataSelect.Controls.Add(this.DtpMax);
      this.tabDataSelect.Controls.Add(this.DtpMin);
      this.tabDataSelect.Controls.Add(this.label4);
      this.tabDataSelect.Controls.Add(this.btnImportRoutes);
      this.tabDataSelect.Controls.Add(this.lbxRoutes);
      this.tabDataSelect.Controls.Add(this.lblLoadData);
      this.tabDataSelect.Location = new System.Drawing.Point(4, 22);
      this.tabDataSelect.Name = "tabDataSelect";
      this.tabDataSelect.Padding = new System.Windows.Forms.Padding(3);
      this.tabDataSelect.Size = new System.Drawing.Size(695, 500);
      this.tabDataSelect.TabIndex = 2;
      this.tabDataSelect.Text = "Datenauswahl";
      this.tabDataSelect.UseVisualStyleBackColor = true;
      // 
      // lblMaxDay
      // 
      this.lblMaxDay.AutoSize = true;
      this.lblMaxDay.Location = new System.Drawing.Point(306, 37);
      this.lblMaxDay.Name = "lblMaxDay";
      this.lblMaxDay.Size = new System.Drawing.Size(27, 13);
      this.lblMaxDay.TabIndex = 13;
      this.lblMaxDay.Text = "Max";
      // 
      // lblMinDay
      // 
      this.lblMinDay.AutoSize = true;
      this.lblMinDay.Location = new System.Drawing.Point(205, 37);
      this.lblMinDay.Name = "lblMinDay";
      this.lblMinDay.Size = new System.Drawing.Size(24, 13);
      this.lblMinDay.TabIndex = 12;
      this.lblMinDay.Text = "Min";
      // 
      // DtpMax
      // 
      this.DtpMax.Format = System.Windows.Forms.DateTimePickerFormat.Time;
      this.DtpMax.Location = new System.Drawing.Point(309, 53);
      this.DtpMax.Name = "DtpMax";
      this.DtpMax.ShowUpDown = true;
      this.DtpMax.Size = new System.Drawing.Size(66, 20);
      this.DtpMax.TabIndex = 11;
      this.DtpMax.ValueChanged += new System.EventHandler(this.OnDtpMax);
      // 
      // DtpMin
      // 
      this.DtpMin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
      this.DtpMin.Location = new System.Drawing.Point(208, 53);
      this.DtpMin.Name = "DtpMin";
      this.DtpMin.ShowUpDown = true;
      this.DtpMin.Size = new System.Drawing.Size(67, 20);
      this.DtpMin.TabIndex = 10;
      this.DtpMin.Value = new System.DateTime(2017, 3, 26, 0, 0, 0, 0);
      this.DtpMin.ValueChanged += new System.EventHandler(this.OnDtpMin);
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
      this.btnImportRoutes.Location = new System.Drawing.Point(6, 460);
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
      this.lbxRoutes.Size = new System.Drawing.Size(165, 420);
      this.lbxRoutes.TabIndex = 5;
      this.lbxRoutes.SelectedIndexChanged += new System.EventHandler(this.OnLbxRoutesSelectedItemIndexChanged);
      // 
      // lblLoadData
      // 
      this.lblLoadData.BackColor = System.Drawing.Color.White;
      this.lblLoadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblLoadData.Location = new System.Drawing.Point(0, 0);
      this.lblLoadData.Name = "lblLoadData";
      this.lblLoadData.Size = new System.Drawing.Size(699, 504);
      this.lblLoadData.TabIndex = 9;
      this.lblLoadData.Text = "Lade Daten ...";
      this.lblLoadData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.lblLoadData.UseWaitCursor = true;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(205, 8);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(95, 18);
      this.label3.TabIndex = 14;
      this.label3.Text = "Zeitspanne:";
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(703, 524);
      this.Controls.Add(this.tabCtrl);
      this.Name = "FormMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "GPS-Tracker";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
      this.Load += new System.EventHandler(this.OnFormLoad);
      this.tabCtrl.ResumeLayout(false);
      this.tabMap.ResumeLayout(false);
      this.tabMap.PerformLayout();
      this.gbStatistic.ResumeLayout(false);
      this.gbStatistic.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
      this.tabHigh.ResumeLayout(false);
      this.panelHeightprofile.ResumeLayout(false);
      this.panelHeightprofile.PerformLayout();
      this.tabDataSelect.ResumeLayout(false);
      this.tabDataSelect.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private GMap.NET.WindowsForms.GMapControl gMap;
    private System.Windows.Forms.TabControl tabCtrl;
    private System.Windows.Forms.TabPage tabMap;
    private System.Windows.Forms.TabPage tabHigh;
    private GraphPanel panelHeightprofile;
    private System.Windows.Forms.Label lblTime;
    private System.Windows.Forms.Label lblHeight;
    private System.Windows.Forms.TrackBar slider;
    private System.Windows.Forms.TabPage tabDataSelect;
    private System.Windows.Forms.ListBox lbxRoutes;
    private System.Windows.Forms.Button btnImportRoutes;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label lblLoadData;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lblRealDistance;
    private System.Windows.Forms.Label lblDistance;
    private System.Windows.Forms.GroupBox gbStatistic;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label lblHeightAbs;
    private System.Windows.Forms.Label lblHeightDif;
    private System.Windows.Forms.Button btnCenterMap;
    private System.Windows.Forms.DateTimePicker DtpMin;
    private System.Windows.Forms.DateTimePicker DtpMax;
    private System.Windows.Forms.Label lblMaxDay;
    private System.Windows.Forms.Label lblMinDay;
    private System.Windows.Forms.Label label3;
  }
}

