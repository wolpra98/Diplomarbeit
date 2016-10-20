﻿using System;
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

    public Form1()
    {
      InitializeComponent();
    }

    private void OnFormLoad(object sender, EventArgs e)
    {
      MinimumSize = new Size(500, 300);
      gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
      GMaps.Instance.Mode = AccessMode.ServerOnly;
      gMap.Position = new PointLatLng(47.092240, 15.402685);
      gMap.ShowCenter = false;
      overlay = new GMapOverlay("overlay");
      gMap.Overlays.Add(overlay);
      route = new GMapRoute("route");
      heightGraph = new HeightGraph();
      panelHeightprofile.Init();
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
      demoData.Add(new HeightData(229f, new TimeSpan(11, 48, 0)));
      demoData.Add(new HeightData(270f, new TimeSpan(12, 10, 0)));
      demoData.Add(new HeightData(252f, new TimeSpan(12, 20, 0)));
      demoData.Add(new HeightData(343f, new TimeSpan(12, 30, 0)));
      demoData.Add(new HeightData(531f, new TimeSpan(12, 40, 0)));
      demoData.Add(new HeightData(472f, new TimeSpan(12, 45, 0)));
      demoData.Add(new HeightData(279f, new TimeSpan(12, 50, 0)));
      demoData.Add(new HeightData(271.4f, new TimeSpan(12, 52, 0)));
      demoData.Add(new HeightData(523f, new TimeSpan(12, 55, 0)));
      demoData.Add(new HeightData(287f, new TimeSpan(11, 57, 0)));
      demoData.Add(new HeightData(333f, new TimeSpan(13, 1, 0)));
      return demoData;
    }

    private void OnTestButtonClick(object sender, EventArgs e)
    {
      List<string> TestLine = new List<string>();
      TestLine.Add("$GPRMC,123519,A,4807.038,S,01131.000,E,022.4,084.4,230394,003.1,W*6A");
      ImportManager test = new ImportManager(TestLine);
      test.ImportGPS();
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
  }
}
