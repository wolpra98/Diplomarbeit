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
    public Form1()
    {
      InitializeComponent();
    }

    private void OnFormLoad(object sender, EventArgs e)
    {
      gMap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
      GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
      gMap.SetPositionByKeywords("Graz, Austria");
    }
  }
}
