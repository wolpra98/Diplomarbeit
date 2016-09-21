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

namespace GPS_Tracker
{
  public partial class Form1 : Form
  {
    GMapOverlay overlay;
    GMapMarker marker;
    GMapRoute route;
    PointLatLng pos;

    public Form1()
    {
      InitializeComponent();
    }

    private void OnFormLoad(object sender, EventArgs e)
    {
      gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
      GMaps.Instance.Mode = AccessMode.ServerOnly;
      gMap.Position = new PointLatLng(47.092240, 15.402685);
      gMap.ShowCenter = false;
      overlay = new GMapOverlay("overlay");
      gMap.Overlays.Add(overlay);
      route = new GMapRoute("route");
    }

    private void OnBtnSetRouteClick(object sender, EventArgs e)
    {
      pos.Lat = Convert.ToDouble(numLat.Value);
      pos.Lng = Convert.ToDouble(numLng.Value);
      marker = new GMarkerGoogle(pos, GMarkerGoogleType.black_small);
      route.Points.Add(pos);
      overlay.Markers.Add(marker);
      overlay.Routes.Clear();
      overlay.Routes.Add(route);
    }
  }
}
