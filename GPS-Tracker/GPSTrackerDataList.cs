using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS_Tracker
{
  class GPSTrackerDataList : Collection<GPSTrackerData>
  {
    public string Text { get; set; }

    public GPSTrackerDataList() : base() { }
  }
}
