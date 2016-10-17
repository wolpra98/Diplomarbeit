using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace GPS_Tracker
{
  class GraphPanel : Panel
  {
    public GraphPanel() : base() { }

    public void Init()
    {
      base.DoubleBuffered = true;
      SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      SetStyle(ControlStyles.ResizeRedraw, true);
      SetStyle(ControlStyles.UserPaint, true);
      SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      UpdateStyles();
    }
  }
}
