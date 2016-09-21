using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GPS_Tracker
{
  class HeightGraph
  {
    List<HeightData> _dataList;
    Graphics _gfx;
    Size _size;

    public HeightGraph(List<HeightData> parData = null)
    {
      _dataList = parData;
    }

    public void DrawGraph(Graphics parGfx, Size parSize)
    {
      _gfx = parGfx;
      _size = parSize;
    }
  }
}
