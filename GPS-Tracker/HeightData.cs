using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS_Tracker
{
  struct HeightData
  {
    public float Height;
    public TimeSpan Time;

    public HeightData(float parHeight, TimeSpan parTime)
    {
      Time = parTime;
      Height = parHeight;
    }
  }
}
