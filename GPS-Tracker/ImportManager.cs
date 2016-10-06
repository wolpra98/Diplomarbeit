using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS_Tracker
{
  class ImportManager
  {
    List<string> _inLine;
    string[] _splitLine;
    float _Lng, _Lat;
    TimeSpan _Time= new TimeSpan();

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
              // _Time. = (int)(Convert.ToInt32(_splitLine[1]) / 10000);

              break;

            default:
              break;
          }
        }
      }
    }


  }
}
