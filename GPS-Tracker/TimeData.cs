using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS_Tracker
{
  class TimeData
  {
    float _timeHours = 0;
    string _timeString;

    public float TimeHours
    {
      get
      {
        return _timeHours;
      }

      set
      {
        _timeHours = value;
      }
    }

    public float TimeMinutes
    {
      get
      {
        return _timeHours * 60f;
      }

      set
      {
        _timeHours = value / 60f;
      }
    }

    public TimeData() { }

    public TimeData(int parHours, int parMinutes = 0, int parSeconds = 0)
    {
      _timeHours = parHours + parMinutes / 60f + parSeconds / 3600f;
    }

    public TimeData(float parTimeHour)
    {
      _timeHours = parTimeHour;
    }

    public override string ToString()
    {
      _timeString = _timeHours.ToString("00") + ":" + (_timeHours * 60 % 60).ToString("00") + ":" + (_timeHours * 3600 % 60).ToString("00");
      return _timeString;
    }
  }
}
