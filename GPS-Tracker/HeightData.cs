using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS_Tracker
{
  struct HeightData
  {
    public static readonly HeightData Empty;
    public float Height;
    public DateTime DateTime;

    public HeightData(float parHeight, DateTime parDateTime)
    {
      DateTime = parDateTime;
      Height = parHeight;
    }
  }
}
