﻿using System;
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
    public DateTime DateTime;

    private bool isValid;

    public bool IsValid
    {
      get
      {
        return isValid;
      }
    }

    public GPSData(float parLng, float parLat, DateTime parTime)
    {
      isValid = false;
      Lng = parLng;
      Lat = parLat;
      DateTime = parTime;
      if (DateTime != null)
        isValid = true;
    }

    public GPSData(string parNmea, DateTime parDateTime)
    {
      isValid = false;
      Lat = 0.0f;
      Lng = 0.0f;
      DateTime = parDateTime;
      if (isGGA(parNmea))
      {
        string[] split = parNmea.Split(',');
        if ((split[2] != "") && (split[2] != "") && (split[2] != "") && (split[2] != ""))
        {
          int time = ((int)Convert.ToSingle(split[1])) / 1000;
          Lat = ((Convert.ToSingle(split[2]) / 10000.0f) % 100) / 60.0f + (int)(Convert.ToSingle(split[2]) / 1000000.0f);
          if (split[3] == "S")
            Lat = -Lat;
          Lng = ((Convert.ToSingle(split[4]) / 10000.0f) % 100) / 60.0f + (int)(Convert.ToSingle(split[4]) / 1000000.0f);
          if (split[5] == "W")
            Lng = -Lng;
          isValid = true;
          Debug.WriteLine("{0}: {1} : {2}", DateTime, Lat, Lng);
        }
      }
    }

    private bool isGGA(string parNmea)
    {
      if (parNmea.Substring(0, 6) == "$GPGGA")
        return true;
      return false;
    }
  }
}
