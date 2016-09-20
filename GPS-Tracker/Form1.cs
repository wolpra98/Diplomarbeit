using System;
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
    GMap.NET.WindowsForms.GMapMarker marker;
    GMap.NET.PointLatLng pos;

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
      gMap.Overlays.Add(markers);
    }

    private void OnBtnSetRouteClick(object sender, EventArgs e)
    {
      pos.Lat = Convert.ToDouble(numLat.Value);
      pos.Lng = Convert.ToDouble(numLng.Value);
      marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(pos, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.pink_pushpin);
      markers.Markers.Add(marker);
    }
  }
}
