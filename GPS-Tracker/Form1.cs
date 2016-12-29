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

namespace GPS_Tracker
{
  public partial class Form1 : Form
  {
    GMapOverlay overlay;
    //GMapMarker marker;
    GMapRoute route;
    PointLatLng pos;
    List<HeightData> heights;
    HeightGraph heightGraph;
    PointF pOffset;
    HeightData pData;
    SerialPort com;
    Thread import;
    bool isRunning;

    public Form1()
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
      heights = demoHeights();
      heightGraph.UpdateData(heights);
      panelHeightprofile.Invalidate();
    }

    private List<HeightData> demoHeights()
    {
      List<HeightData> demoData = new List<HeightData>();
      demoData.Add(new HeightData(229f, new TimeSpan(12, 48, 0)));
      demoData.Add(new HeightData(270f, new TimeSpan(12, 39, 0)));
      demoData.Add(new HeightData(252f, new TimeSpan(12, 27, 0)));
      demoData.Add(new HeightData(343f, new TimeSpan(12, 30, 0)));
      demoData.Add(new HeightData(531f, new TimeSpan(12, 40, 0)));
      demoData.Add(new HeightData(472f, new TimeSpan(12, 45, 0)));
      demoData.Add(new HeightData(279f, new TimeSpan(12, 50, 0)));
      demoData.Add(new HeightData(271.4f, new TimeSpan(12, 52, 0)));
      demoData.Add(new HeightData(523f, new TimeSpan(12, 55, 0)));
      demoData.Add(new HeightData(287f, new TimeSpan(12, 57, 0)));
      demoData.Add(new HeightData(333f, new TimeSpan(12, 43, 0)));
      return demoData;
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

    void RefreshPosData()
    {
      pOffset = heightGraph.ReturnOffset();
      pData = heightGraph.ReturnData();
      if (pOffset != PointF.Empty)
      {
        lblHeight.Text = pData.Height.ToString() + " m";
        lblTime.Font = lblHeight.Font;
        lblTime.Text = pData.Time.ToString(@"hh\:mm");
        pOffset.Y = 11;
        pOffset.X -= lblHeight.Width / 2.0f;
        lblHeight.Location = panelHeightprofile.Location + (Size)Point.Round(pOffset);
        pOffset = heightGraph.ReturnOffset();
        pOffset.Y = panelHeightprofile.Height - 20;
        pOffset.X -= lblTime.Width / 2.0f;
        lblTime.Location = panelHeightprofile.Location + (Size)Point.Round(pOffset);
      }
    }

    private void OnBtnImportClick(object sender, EventArgs e)
    {

      string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Noqq\Documents\Diplomarbeit\GPS-DATA.TXT");

      foreach (string line in lines)
      {
        GPSData data = new GPSData(line);
        pos.Lat = data.Lat; pos.Lng = data.Lng;
        route.Points.Add(pos);
      }
      overlay.Routes.Clear();
      overlay.Routes.Add(route);
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

    void GetData()
    {
      heights = new List<HeightData>();
      while (isRunning)
      {
        try
        {
          string[] rData = com.ReadLine().Split(';');
          if (rData[0] != null && rData[1] != null)
          {
            GPSData data = new GPSData(rData[0]);
            if (data.IsValid)
            {
              pos.Lat = data.Lat; pos.Lng = data.Lng;
              route.Points.Add(pos);
              heights.Add(new HeightData(Convert.ToSingle(rData[1]) / 100.0f, data.Time));
              heightGraph.UpdateData(heights);
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

    private void OnFormClosing(object sender, FormClosingEventArgs e)
    {
      isRunning = false;
    }

    private void OnBtnCenterMapClick(object sender, EventArgs e)
    {
      gMap.Position = pos;
    }
  }
}
