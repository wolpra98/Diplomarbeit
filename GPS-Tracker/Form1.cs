﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPS_Tracker
{
  public partial class Form1 : Form
  {
    GMap.NET.WindowsForms.GMapOverlay markers;

    public Form1()
    {
      InitializeComponent();
    }

    private void OnFormLoad(object sender, EventArgs e)
    {
      gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
      GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
      gMap.Position = new GMap.NET.PointLatLng(47.092240, 15.402685);
      gMap.ShowCenter = false;
      markers = new GMap.NET.WindowsForms.GMapOverlay("markers");
    }

    private void OnBtnSetRouteClick(object sender, EventArgs e)
    {
      GMap.NET.WindowsForms.GMapMarker marker =
          new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
              new GMap.NET.PointLatLng(47.092240, 15.402685),
              GMap.NET.WindowsForms.Markers.GMarkerGoogleType.arrow);
      markers.Markers.Add(marker);
      gMap.Overlays.Add(markers);
    }
  }
}
