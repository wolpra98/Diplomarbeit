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

    private bool isValid;

    public bool IsValid
    {
      get
      {
        return isValid;
      }
    }

    public GPSData(float parLng, float parLat, TimeSpan parTime)
    {
      isValid = false;
      Lng = parLng;
      Lat = parLat;
      Time = parTime;
      if (Lng != 999.9f && Lat != 999.9f && Time != null)
        isValid = true;
    }

    public GPSData(string nmea)
    {
      isValid = false;
      Lat = 999.9f;
      Lng = 999.9f;
      Time = new TimeSpan();
      if (isGGA(nmea))
      {
        string[] split = nmea.Split(',');
        int time = ((int)Convert.ToSingle(split[1])) / 1000;
        Time = new TimeSpan(time / 10000, (time / 100) % 100, time % 100);
        Lat = ((Convert.ToSingle(split[2]) / 100000.0f) % 100) / 60.0f + (int)(Convert.ToSingle(split[2]) / 10000000.0f);
        if (split[3] == "S")
          Lat = -Lat;
        Lng = ((Convert.ToSingle(split[4]) / 100000.0f) % 100) / 60.0f + (int)(Convert.ToSingle(split[4]) / 10000000.0f);
        if (split[5] == "W")
          Lng = -Lng;
        isValid = true;
        Debug.WriteLine("{0}: {1} : {2}", Time, Lat, Lng); 
      }
    }

    private bool isGGA(string nmea)
    {
      //if (nmea.Length < 6)
      //return false;
      if (nmea.Substring(0, 6) == "$GPGGA")
        return true;
      return false;
    }
  }
}
