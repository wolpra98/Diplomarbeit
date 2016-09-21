using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS_Tracker
{
  class HeightData
  {
    float _height;
    TimeData _time;

    public HeightData() { }

    public HeightData(float parHeight = 0f, TimeData parTime = null)
    {
      Height = parHeight;
      Time = parTime;
    }

    public float Height
    {
      get
      {
        return _height;
      }

      set
      {
        _height = value;
      }
    }

    public TimeData Time
    {
      get
      {
        return _time;
      }

      set
      {
        if (value == null)
          _time = new TimeData(0);
        else
          _time = value;
      }
    }
  }
}
