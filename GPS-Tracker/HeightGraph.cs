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
    List<HeightData> _dataList = null;
    Graphics _gfx;
    Size _size;
    PointF _pZero;
    Pen _penAxes;
    float _maxHeight, _minHeight, _scaleHeight, _multHeight;
    int _scaleMinHeight;
    const float PADT = 15f, PADB = 15f, PADL = 50f, PADR = 15f, SCAL = 15;

    public HeightGraph() { }

    public void DrawGraph(Graphics parGfx, Size parSize, List<HeightData> parData)
    {
      _dataList = parData;
      _gfx = parGfx;
      _size = parSize;
      drawAxes();
    }

    void drawAxes()
    {
      _pZero = new PointF(PADL, _size.Height - PADB);
      _penAxes = new Pen(Color.Black, 2f);
      _gfx.DrawLine(_penAxes, _pZero, new PointF(PADL, PADT));
      _gfx.DrawLine(_penAxes, _pZero, new PointF(_size.Width - PADR, _pZero.Y));
      if (_dataList != null)
      {
        _maxHeight = _dataList.Max(d => d.Height);
        _minHeight = _dataList.Min(d => d.Height);
        _scaleHeight = 0;
        for (int i = 1; _scaleHeight < SCAL; i *= 10)
        {
          for (int j = 1; _scaleHeight < SCAL; j *= 5)
          {
            if (j > 5) break;
            _scaleHeight = (_size.Height - PADT - PADB) * i * j / (_maxHeight - _minHeight);
            _multHeight = i * j;
            //_scaleMinHeight= (_minHeight+i*j/2)
          }
        }
        _penAxes.Width = 1f;
        for (int i = 1; i < ((_size.Height - PADT - PADB) / _scaleHeight); i++)
        {
          _gfx.DrawLine(_penAxes, PADL - SCAL / 2, _pZero.Y - i * _scaleHeight, PADL + SCAL / 2, _pZero.Y - i * _scaleHeight);
          _gfx.DrawString(_scaleHeight.ToString("0"), new Font("Calibri", 12), Brushes.Black, 15, _pZero.Y - i * _scaleHeight - 10);
        }
      }
    }
  }
}
