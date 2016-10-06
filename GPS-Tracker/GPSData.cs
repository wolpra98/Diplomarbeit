using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS_Tracker
{
  struct GPSData
  {
    public float Lng;  // N;S
    public float Lat;  // W;E
    public TimeSpan Time; 

    public GPSData(float parLng, float parLat, TimeSpan parTime)
    {
      Lng = parLng;
      Lat = parLat;
      Time = parTime;
    }
  }
}
