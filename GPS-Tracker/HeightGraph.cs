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
    PointF _pZero;
    Pen _penAxes;
    float _maxHeight, _minHeight, _scaleHeight, _multHeight, _scaleMinHeight, _scaleMaxHeight, _multWidth ;
    TimeSpan _minTime, _maxTime, _scaleMaxTime, _scaleMinTime;
    const float PADT = 15f, PADB = 70f, PADL = 50f, PADR = 15f, SCAL = 15;

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
      _penAxes.Width = 1f;
      if (_dataList != null)
      {
        // Y Axe
        _maxHeight = _dataList.Max(h => h.Height);
        _minHeight = _dataList.Min(h => h.Height);
        _scaleHeight = 0;
        for (int i = 1; _scaleHeight < SCAL; i *= 10)
        {
          for (int j = 1; _scaleHeight < SCAL; j *= 5)
          {
            if (j > 5) break;
            _multHeight = i * j;
            _scaleMinHeight = (int)(_minHeight / _multHeight) * _multHeight;
            _scaleMaxHeight = _multHeight * ((int)(_maxHeight / _multHeight) + 1);
            _scaleHeight = (_size.Height - PADT - PADB) * i * j / (_scaleMaxHeight - _scaleMinHeight);
          }
        }
        for (int i = 0; i < ((_size.Height - PADT - PADB - 1) / _scaleHeight); i++)
        {
          _gfx.DrawLine(_penAxes, PADL - SCAL / 2, _pZero.Y - i * _scaleHeight, PADL, _pZero.Y - i * _scaleHeight);
          _gfx.DrawString((_scaleMinHeight + i * _multHeight).ToString("0"), new Font("Calibri", 12), Brushes.Black, 15, _pZero.Y - i * _scaleHeight - 10);
        }

        // X Axe
        _maxTime = _dataList.Max(t => t.Time);
        _minTime = _dataList.Min(t => t.Time);
        _gfx.DrawString(_minTime.ToString(), new Font("Calibri", 12), Brushes.Black, _pZero, new StringFormat(StringFormatFlags.DirectionVertical));
      }
    }
  }
}
