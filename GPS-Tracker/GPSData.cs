using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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

    public GPSData(string nmea)
    {
      string[] split = nmea.Split(',');
      int time = ((int)Convert.ToSingle(split[1])) / 1000;
      Time = new TimeSpan(time / 10000, (time / 100) % 100, time % 100);
      Lat = ((Convert.ToSingle(split[2]) / 10000.0f) % 100) / 60.0f + (int)(Convert.ToSingle(split[2]) / 1000000.0f);
      if (split[3] == "S")
        Lat = -Lat;
      Lng = ((Convert.ToSingle(split[4]) / 10000.0f) % 100) / 60.0f + (int)(Convert.ToSingle(split[4]) / 1000000.0f);
      if (split[5] == "W")
        Lng = -Lng;
      Debug.WriteLine("{0}: {1} : {2}", Time, Lat, Lng);
    }
  }
}
