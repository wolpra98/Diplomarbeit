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
using System.Diagnostics;
using System.IO;

namespace GPS_Tracker
{
  public partial class FormMain : Form
  {
    #region Vriables
    StatisticManager statMgr = new StatisticManager();
    GMapOverlay overlay;
    //GMapMarker marker;
    GMapRoute route;
    PointLatLng pos;
    List<GPSTrackerData> data;
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
      data = new List<GPSTrackerData>();
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
          Debug.WriteLine("Thread crash!");
        }
      }
    }

    void RefreshPosData()
    {
      pOffset = heightGraph.ReturnOffset();
      pData = heightGraph.ReturnData();
      if (pOffset != PointF.Empty)
      {
        lblHeight.Text = pData.Height.ToString() + " m";
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

    private void OnBtnSetRouteClick(object sender, EventArgs e)
    {
      pos.Lat = Convert.ToDouble(numLat.Value);
      pos.Lng = Convert.ToDouble(numLng.Value);
      //marker = new GMarkerGoogle(pos, GMarkerGoogleType.black_small);
      route.Points.Add(pos);
      //overlay.Markers.Add(marker);
      overlay.Routes.Clear();
      overlay.Routes.Add(route);
    }

    private void OnButtonHeightClick(object sender, EventArgs e)
    {
      //heights = demoHeights();
      //heightGraph.UpdateData(heights);
      //panelHeightprofile.Invalidate();
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

    private void OnBtnImportClick(object sender, EventArgs e)
    {
      GPSTrackerData data = new GPSTrackerData(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
      /*
      string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Noqq\Documents\Diplomarbeit\GPS-DATA.TXT");

      foreach (string line in lines)
      {
        GPSTrackerData data = new GPSTrackerData();
        data.GPSData(line);
        if (data.IsValid)
        {
          pos.Lat = data.Lat; pos.Lng = data.Lng;
          route.Points.Add(pos);
        }
      }
      overlay.Routes.Clear();
      overlay.Routes.Add(route);*/
    }

    private void OnBtnClearClick(object sender, EventArgs e)
    {
      route.Points.Clear();
      overlay.Routes.Clear();
    }

    private void OnMapZoomChanged()
    {
      slider.Value = (int)gMap.Zoom;
    }

    private void OnValueChanged(object sender, EventArgs e)
    {
      gMap.Zoom = slider.Value;
    }

    private void OnRefreshClick(object sender, EventArgs e)
    {
      cbxCOM.Items.Clear();
      cbxCOM.Items.AddRange(SerialPort.GetPortNames());
      if (cbxCOM.Items.Count != 0)
        cbxCOM.SelectedItem = cbxCOM.Items[0];
    }

    private void OnConnectClick(object sender, EventArgs e)
    {
      if (com.IsOpen)
      {
        com.Close();
        btnConnect.Text = "Connect";
        isRunning = false;
      }
      else
      {
        try
        {
          btnConnect.Enabled = false;
          com.PortName = cbxCOM.SelectedItem.ToString();
          if (cbxBaud.SelectedItem != null)
            com.BaudRate = Convert.ToInt32(cbxBaud.SelectedItem);
          else
            com.BaudRate = 115200;
          com.Open();
          btnConnect.Text = "Disconnect";
          isRunning = true;
          import = new Thread(new ThreadStart(GetData));
          import.Start();
          btnConnect.Enabled = true;
        }
        catch (Exception)
        {
          MessageBox.Show("Failed to connect!");
          btnConnect.Enabled = true;
        }
      }
    }

    private void OnBaudChanged(object sender, EventArgs e)
    {
      if (cbxBaud.SelectedItem != null)
        com.BaudRate = Convert.ToInt32(cbxBaud.SelectedItem);
    }

    private void OnFormClosing(object sender, FormClosingEventArgs e)
    {
      isRunning = false;
    }

    private void OnBtnCenterMapClick(object sender, EventArgs e)
    {
      gMap.Position = pos;
    }

    private void OnBtnImportRoutesClick(object sender, EventArgs e)
    {
      var popup = new FormImport();
      popup.ShowDialog();
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
      else if (tabCtrl.SelectedTab == tabDataSelect && dataChanged)
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
        dataChanged = false;
      }
    }
  }
}
