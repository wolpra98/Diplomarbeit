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
    List<PointF> _dataPoints;
    Graphics _gfx;
    Size _size;
    PointF _pZero;
    Pen _pen;
    int _multWidth, _multHeight;
    float _maxHeight, _minHeight, _scaleHeight, _scaleMinHeight, _scaleMaxHeight, _scaleWidth;
    TimeSpan _minTime, _maxTime, _scaleMaxTime, _scaleMinTime;
    const float PADT = 15f, PADB = 60f, PADL = 50f, PADR = 15f, SCAL = 15;

    public HeightGraph()
    {

    }

    public void DrawGraph(Graphics parGfx, Size parSize, List<HeightData> parData)
    {
      _dataList = parData;
      _gfx = parGfx;
      _size = parSize;
      drawAxes();
      drawData();
    }

    void drawAxes()
    {
      _pZero = new PointF(PADL, _size.Height - PADB);
      _pen = new Pen(Color.Black, 2f);
      _gfx.DrawLine(_pen, _pZero, new PointF(PADL, PADT));
      _gfx.DrawLine(_pen, _pZero, new PointF(_size.Width - PADR, _pZero.Y));
      _pen.Width = 1f;
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
            _scaleMaxHeight = (int)(_maxHeight / _multHeight) * _multHeight;
            if (_scaleMaxHeight < _maxHeight)
              _scaleMaxHeight += _multHeight;
            _scaleHeight = (_size.Height - PADT - PADB) * i * j / (_scaleMaxHeight - _scaleMinHeight);
          }
        }
        for (int i = 0; _scaleMinHeight + i * _multHeight <= _scaleMaxHeight; i++)
        {
          _gfx.DrawLine(_pen, PADL - SCAL / 2, _pZero.Y - i * _scaleHeight, PADL, _pZero.Y - i * _scaleHeight);
          _gfx.DrawString((_scaleMinHeight + i * _multHeight).ToString("0"), new Font("Calibri", 12), Brushes.Black, 15, _pZero.Y - i * _scaleHeight - 10);
        }

        // X Axe
        _maxTime = _dataList.Max(t => t.Time);
        _minTime = _dataList.Min(t => t.Time);
        _scaleWidth = 0;
        _multWidth = 0;
        while (_scaleWidth <= SCAL * 3)
        {
          if (_multWidth < 15)
            _multWidth += 5;
          else
            _multWidth *= 2;
          _scaleMinTime = new TimeSpan((int)(_minTime.Ticks / TimeSpan.TicksPerMinute / _multWidth) * _multWidth * TimeSpan.TicksPerMinute);
          _scaleMaxTime = new TimeSpan((int)(_maxTime.Ticks / TimeSpan.TicksPerMinute / _multWidth) * _multWidth * TimeSpan.TicksPerMinute);
          if (_scaleMaxTime < _maxTime)
            _scaleMaxTime += new TimeSpan(_multWidth * TimeSpan.TicksPerMinute);
          _scaleWidth = (_size.Width - PADL - PADR) * _multWidth / (int)_scaleMaxTime.Subtract(_scaleMinTime).TotalMinutes;
        }
        for (int i = 0; _scaleMinTime.TotalMinutes + i * _multWidth <= _scaleMaxTime.TotalMinutes; i++)
        {
          _gfx.DrawLine(_pen, _pZero.X + i * _scaleWidth, _pZero.Y, _pZero.X + i * _scaleWidth, _pZero.Y + SCAL / 2);
          _gfx.DrawString(new TimeSpan(_scaleMinTime.Ticks + i * _multWidth * TimeSpan.TicksPerMinute).ToString(@"hh\:mm"), new Font("Calibri", 12), Brushes.Black, _pZero.X + i * _scaleWidth - 10, _pZero.Y + 10, new StringFormat(StringFormatFlags.DirectionVertical));
        }
      }
    }

    void drawData()
    {
      _pen.Color = Color.Blue;
      _pen.Width = 5;
      if (_dataList != null)
      {
        if (_dataPoints == null)
          _dataPoints = new List<PointF>();
        _dataPoints.Clear();
        foreach (HeightData data in _dataList)
        {
          _dataPoints.Add(new PointF(Convert.ToSingle(data.Time.Subtract(_scaleMinTime).TotalMinutes * _scaleWidth / _multWidth) + _pZero.X, _pZero.Y - (data.Height - _scaleMinHeight) * _scaleHeight / _multHeight));
        }
        _gfx.DrawLines(_pen, _dataPoints.ToArray());
      }
    }
  }
}
