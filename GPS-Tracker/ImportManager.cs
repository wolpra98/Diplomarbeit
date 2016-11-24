using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GPS_Tracker
{
  class ImportManager
  {
    List<string> _inLine;
    string[] _splitLine;
    float _Lng, _Lat;
    int _timeH, _timeM, _timeS;
    float _veloKmh;
    int _dateY, _dateM, _dateD;
    TimeSpan _Time;

    public ImportManager() { }

    public ImportManager(List<String> parInLine)
    {
      _inLine = parInLine;
    }

    public void ImportGPS()
    {
      foreach (string Line in _inLine)
      {

        if (Line.Contains("$GP"))
        {
          _splitLine = Line.Split(',');
          switch (_splitLine[0])
          {
            case "$GPRMC":
              if (_splitLine[2] == "V")
                break;
              GetTime(_splitLine[1]);
              Debug.WriteLine("Time = {0}:{1}:{2}", _timeH, _timeM, _timeS);

              GetGPS(_splitLine[3], _splitLine[4], _splitLine[5], _splitLine[6]);
              Debug.WriteLine("Lng = {0}", _Lng);
              Debug.WriteLine("Lat = {0}", _Lat);

              _veloKmh = Convert.ToSingle(_splitLine[7]) / 10 * 1.852f;
              Debug.WriteLine("Velo = {0}", _veloKmh);

              GetDate(_splitLine[9]);
              Debug.WriteLine("Date = {0}.{1}.{2}", _dateD, _dateM, _dateY);

              break;

            default:
              break;
          }
        }
      }
    }

    private void GetDate(string parDate)
    {
      _dateD = (int)(Convert.ToInt32(parDate) / 10000);
      _dateM = (int)((Convert.ToInt32(parDate) % 10000) / 100);
      _dateY = Convert.ToInt32(parDate) % 100;
    }

    private void GetGPS(string parLng, string parNS, string parLat, string parWE)
    {
      _Lng = Convert.ToSingle(parLng) / 100000;
      if (parNS == "S")
        _Lng = -_Lng;
      _Lat = Convert.ToSingle(parLat) / 100000;
      if (parWE == "W")
        _Lat = -_Lat;
    }

    private void GetTime(string parTime)
    {
      _timeH = Convert.ToInt32(parTime) / 10000;
      _timeM = (Convert.ToInt32(parTime) % 10000) / 100;
      _timeS = Convert.ToInt32(parTime) % 100;
    }

  }
}
