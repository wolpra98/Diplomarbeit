using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS_Tracker
{
  struct GPSTrackerData
  {
    public float Lng;  // N;S
    public float Lat;  // W;E
    public DateTime Datetime;
    public static readonly GPSTrackerData Empty;
    public float Height;
    public float Offset;

    private bool isValid;


    public GPSTrackerData(byte[] parImport)
    {
      isValid = false;
      Lat = 0;
      Lng = 0;
      Offset = 0;
      int date = BitConverter.ToInt32(parImport, 0);
      int time = BitConverter.ToInt32(parImport, 4);
      long datetime = ((long)date) * 1000000 + time;
      if(date==0||time==0)
      {
        isValid = false;
        Datetime = DateTime.Now;
      }
      else
        Datetime = DateTime.ParseExact(datetime.ToString("000000000000"), "ddMMyyHHmmss", null);
      Height = BitConverter.ToSingle(parImport, 8);
      GPSData(Encoding.ASCII.GetString(parImport,12,88));
      Offset -= Height;
    }

    public bool IsValid
    {
      get
      {
        return isValid;
      }
    }

    public void GPSData(float parLng, float parLat)
    {
      isValid = false;
      Lng = parLng;
      Lat = parLat;
    }

    public void GPSData(string parNmea)
    {
      isValid = false;
      Lat = 0.0f;
      Lng = 0.0f;
      if (isGGA(parNmea))
      {
        string[] split = parNmea.Split(',');
        if ((split[2] != "") && (split[3] != "") && (split[4] != "") && (split[5] != "") && (split[9] != "") && (split[11] != ""))
        {
          Lat = ((Convert.ToSingle(split[2]) / 100000.0f) % 100) / 60.0f + (int)(Convert.ToSingle(split[2]) / 10000000.0f);
          if (split[3] == "S")
            Lat = -Lat;
          Lng = ((Convert.ToSingle(split[4]) / 100000.0f) % 100) / 60.0f + (int)(Convert.ToSingle(split[4]) / 10000000.0f);
          if (split[5] == "W")
            Lng = -Lng;
          Offset = (Convert.ToSingle(split[9]) + Convert.ToSingle(split[11]))/10;
          isValid = true;
        }
      }
    }

    private bool isGGA(string parNmea)
    {
      if (parNmea.Substring(0, 6) == "$GPGGA")
        return true;
      return false;
    }

    public override string ToString()
    {
      return string.Format("{0} : {1} : {2} : {3}", Datetime.ToString("dd.MM.yyyy HH:mm:ss"), Lat, Lng, Height);
    }
  }
}
