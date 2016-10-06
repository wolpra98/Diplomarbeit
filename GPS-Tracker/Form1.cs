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

namespace GPS_Tracker
{
  public partial class Form1 : Form
  {
    GMapOverlay overlay;
    GMapMarker marker;
    GMapRoute route;
    PointLatLng pos;
    List<HeightData> heights;

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
      panelHeightprofile.Init();
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

    private void OnButtonHeightClick(object sender, EventArgs e)
    {
      heights = demoHeights();
      panelHeightprofile.UpdateData(heights);
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
  }
}
