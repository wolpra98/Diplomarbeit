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
      return "{0}:{1}:{2}";
    }
  }
}
