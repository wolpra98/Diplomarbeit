using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Reflection;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace GPS_Tracker
{
  public partial class FormMain : Form
  {
    #region Vriables
    static readonly float[] zoomScales = {  0.0f,
                                            591657550.5f,
                                            295828775.3f,
                                            147914387.6f,
                                            73957193.82f,
                                            36978596.91f,
                                            18489298.45f,
                                            9244649.227f,
                                            4622324.614f,
                                            2311162.307f,
                                            1155581.153f,
                                            577790.5767f,
                                            288895.2884f,
                                            144447.6442f,
                                            72223.82209f,
                                            36111.91104f,
                                            18055.95552f,
                                            9027.977761f,
                                            4513.98888f,
                                            2256.99444f,
                                            1128.49722f };
    StatisticManager statMgr = new StatisticManager();
    GMapOverlay overlay;
    GMapRoute route;
    GMapMarker marker;
    PointLatLng pos, mPos;
    HeightGraph heightGraph;
    PointF pOffset;
    GPSTrackerData pData;
    SerialPort com;
    Thread import;
    bool isRunning, dataLoaded = false, dataChanged = false;
    #endregion

    #region Functions

    void GetData()
    {
      while (isRunning)
      {
        try
        {
          string[] rData = com.ReadLine().Split(';');
          if (rData[0] != null && rData[1] != null)
          {
            GPSTrackerData data = new GPSTrackerData();
            data.GPSData(rData[0]);
            if (data.IsValid)
            {
              pos.Lat = data.Lat; pos.Lng = data.Lng;
              route.Points.Add(pos);
              //heights.Add(new HeightData(Convert.ToSingle(rData[1]) / 100.0f, data.DateTime));
              //heightGraph.UpdateData(heights);
              panelHeightprofile.Invalidate();
              overlay.Routes.Clear();
              overlay.Routes.Add(route);
            }
          }
        }
        catch (Exception)
        {
          isRunning = false;
        }
      }
    }

    void RefreshPosData()
    {
      pOffset = heightGraph.ReturnOffset();
      pData = heightGraph.ReturnData();
      if (pOffset != PointF.Empty)
      {
        lblHeight.Text = pData.Height.ToString("F0") + " m";
        lblTime.Font = lblHeight.Font;
        lblTime.Text = pData.Datetime.ToString(@"hh\:mm");
        pOffset.Y = 11;
        pOffset.X -= lblHeight.Width / 2.0f;
        lblHeight.Location = panelHeightprofile.Location + (Size)Point.Round(pOffset);
        pOffset = heightGraph.ReturnOffset();
        pOffset.Y = panelHeightprofile.Height - 20;
        pOffset.X -= lblTime.Width / 2.0f;
        lblTime.Location = panelHeightprofile.Location + (Size)Point.Round(pOffset);
      }
    }

    void LoadData()
    {
      List<GPSTrackerDataList> list = new List<GPSTrackerDataList>();
      byte[] buffer = new byte[100];
      string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GPS-Tracker", "Import");
      string name;
      if (!Directory.Exists(@dir))
        Directory.CreateDirectory(@dir);
      foreach (string file in Directory.GetFiles(@dir, "*.gpst"))
      {
        GPSTrackerDataList filedata = new GPSTrackerDataList();
        using (FileStream fs = new FileStream(file, FileMode.Open))
        {
          while (fs.Read(buffer, 0, 100) == 100)
            filedata.Add(new GPSTrackerData(buffer));
        }
        name = file.Replace(dir, "");
        name = name.Replace(".gpst", "");
        name = name.Replace("\\", "");
        name = name.Substring(4, 2) + "." + name.Substring(2, 2) + ".20" + name.Substring(0, 2) + "   " + name.Substring(6, 2) + ":" + name.Substring(8, 2) + " Uhr";
        filedata.Text = name;
        list.Add(filedata);
      }
      lbxRoutes.DisplayMember = "Text";
      lbxRoutes.DataSource = list;
    }

    #endregion

    public FormMain()
    {
      InitializeComponent();
    }

    private void OnFormLoad(object sender, EventArgs e)
    {
      MinimumSize = new Size(500, 300);
      gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
      GMaps.Instance.Mode = AccessMode.ServerAndCache;
      gMap.Position = new PointLatLng(47.092240, 15.402685);
      gMap.ShowCenter = false;
      overlay = new GMapOverlay("overlay");
      gMap.Overlays.Add(overlay);
      route = new GMapRoute("route");
      heightGraph = new HeightGraph();
      panelHeightprofile.Init();
      com = new SerialPort();
    }

    private void OnGraphPanelMouseMove(object sender, MouseEventArgs e)
    {
      heightGraph.MovePosData(e.Location);
      RefreshPosData();
      panelHeightprofile.Invalidate();
    }

    private void OnGraphPanelPaint(object sender, PaintEventArgs e)
    {
      heightGraph.DrawGraph(e.Graphics, panelHeightprofile.Size);
      RefreshPosData();
    }

    private void OnMapZoomChanged()
    {
      slider.Value = (int)gMap.Zoom;
    }

    private void OnValueChanged(object sender, EventArgs e)
    {
      gMap.Zoom = slider.Value;
    }

    private void OnFormClosing(object sender, FormClosingEventArgs e)
    {
      isRunning = false;
    }

    private void OnBtnCenterMapClick(object sender, EventArgs e)
    {
      gMap.ZoomAndCenterRoute(route);
    }

    private void OnBtnImportRoutesClick(object sender, EventArgs e)
    {
      var popup = new FormImport();
      popup.ShowDialog();
    }

    private void OnMapMouseMove(object sender, MouseEventArgs e)
    {
      if (statMgr.Data != null)
      {
        overlay.Markers.Clear();
        pos = PointLatLng.Empty;
        mPos = gMap.FromLocalToLatLng(e.X, e.Y);
        double dist, nDist = (zoomScales[(int)gMap.Zoom]/20000000)* (zoomScales[(int)gMap.Zoom] / 20000000);
        string posText = "";
        foreach (GPSTrackerData item in statMgr.Data)
        {
          dist = (item.Lat - mPos.Lat) * (item.Lat - mPos.Lat) + (item.Lng - mPos.Lng) * (item.Lng - mPos.Lng);
          if (nDist > dist)
          {
            nDist = dist;
            pos.Lat = item.Lat; pos.Lng = item.Lng;
            posText = item.Datetime.ToString(@"hh\:mm") + "\n" + item.Height.ToString("F0") + " m";
          }
        }
        if (!pos.IsEmpty)
        {
          marker = new GMarkerGoogle(pos, GMarkerGoogleType.black_small);
          overlay.Markers.Add(marker);
          marker.ToolTipText = posText;
          marker.ToolTipMode = MarkerTooltipMode.Always;
          marker.ToolTip.Fill = Brushes.Black;
          marker.ToolTip.Foreground = Brushes.White;

        }
      }
    }

    private void OnLbxRoutesSelectedItemIndexChanged(object sender, EventArgs e)
    {
      if (lbxRoutes.SelectedItem != null)
      {
        statMgr.Data = ((GPSTrackerDataList)lbxRoutes.SelectedItem).ToList();
        dataChanged = true;
      }
    }

    private void OnTabChange(object sender, EventArgs e)
    {
      if (tabCtrl.SelectedTab == tabDataSelect && !dataLoaded)
      {
        lblLoadData.BringToFront();
        Application.DoEvents();
        LoadData();
        lblLoadData.Visible = false;
        dataLoaded = true;
      }
      else if (tabCtrl.SelectedTab == tabHigh || tabCtrl.SelectedTab == tabMap)
      {
        gbStatistic.Parent = tabCtrl.SelectedTab;
      }
      if (dataChanged)
      {
        route.Points.Clear();
        overlay.Routes.Clear();
        Application.DoEvents();
        foreach (GPSTrackerData item in statMgr.Data)
        {
          pos.Lat = item.Lat;
          pos.Lng = item.Lng;
          route.Points.Add(pos);
        }
        overlay.Routes.Add(route);
        gMap.ZoomAndCenterRoute(route);
        heightGraph = new HeightGraph();
        heightGraph.UpdateData(statMgr.Data);
        panelHeightprofile.Invalidate();
        if (statMgr.Distance > 1000.0f)
        {
          lblDistance.Text = (statMgr.Distance / 1000).ToString("N2") + " km";
          lblRealDistance.Text = (statMgr.RealDistence / 1000).ToString("N2") + " km";
        }
        else
        {
          lblDistance.Text = statMgr.Distance.ToString("N0") + " m";
          lblRealDistance.Text = statMgr.RealDistence.ToString("N0") + " m";
        }
        lblHeightDif.Text = statMgr.HeightDifference.ToString("N0") + " m";
        lblHeightAbs.Text = statMgr.HeightDistance.ToString("N0") + " m";
        dataChanged = false;
      }
    }
  }
}
