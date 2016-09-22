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

namespace GPS_Tracker
{
  public partial class Form1 : Form
  {
    GMapOverlay overlay;
    GMapMarker marker;
    GMapRoute route;
    PointLatLng pos;
    List<HeightData> heights;
    HeightGraph heightGraph;

    public Form1()
    {
      InitializeComponent();
    }

    private void OnFormLoad(object sender, EventArgs e)
    {
      this.MinimumSize = new Size(500, 300);
      gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
      GMaps.Instance.Mode = AccessMode.ServerOnly;
      gMap.Position = new PointLatLng(47.092240, 15.402685);
      gMap.ShowCenter = false;
      overlay = new GMapOverlay("overlay");
      gMap.Overlays.Add(overlay);
      route = new GMapRoute("route");
      heightGraph = new HeightGraph();
      heights = new List<HeightData>();
      heights.Add(new HeightData(513f, new TimeData(1.1f)));
      heights.Add(new HeightData(913f, new TimeData(1.2f)));
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

    private void OnPanelPaint(object sender, PaintEventArgs e)
    {
      heightGraph.DrawGraph(panelHeightprofile.CreateGraphics(), panelHeightprofile.Size, heights);
    }

    private void OnButtonHeightClick(object sender, EventArgs e)
    {
      TimeData time = new TimeData(1,2,3);
      label3.Text = time.ToString();
    }
  }
}
