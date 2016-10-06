using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace GPS_Tracker
{
  class GraphPanel : Panel
  {
    HeightGraph heightGraph;

    public GraphPanel() : base() { }

    public void Init()
    {
      base.DoubleBuffered = true;
      SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      SetStyle(ControlStyles.ResizeRedraw, true);
      SetStyle(ControlStyles.UserPaint, true);
      SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      UpdateStyles();
      heightGraph = new HeightGraph();
    }
    
    protected override void OnResize(EventArgs e)
    {
      Invalidate();
      base.OnResize(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      heightGraph.DrawGraph(e.Graphics, Size, null);
      Invalidate();
      base.OnPaint(e);
    }

    public void UpdateData(List<HeightData> parData)
    {
      heightGraph.UpdateData(parData);
      //Invalidate();
    }
  }
}
