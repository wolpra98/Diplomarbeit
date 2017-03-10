using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GPS_Tracker
{
  class HeightGraph
  {
    const float PADT = 30f, PADB = 70f, PADL = 50f, PADR = 20, SCAL = 15f;
    #region MemberVariables
    List<GPSTrackerData> _dataList;
    List<PointF> _dataPoints;
    Graphics _gfx;
    GraphicsPath _path;
    Matrix _move;
    Size _size;
    PointF _pZero, _mPos;
    Pen _pen;
    Font _font;
    StringFormat _formatVertical;
    int _multWidth, _multHeight, _nearestPoint, _oldPoint;
    float _maxHeight, _minHeight, _scaleHeight, _scaleMinHeight, _scaleMaxHeight, _scaleWidth;
    DateTime _minTime, _maxTime, _scaleMaxTime, _scaleMinTime;
    bool _refresh;
    #endregion

    public HeightGraph()
    {
      _pen = new Pen(Color.Black, 2f);
      _font = new Font("Calibri", 12);
      _formatVertical = new StringFormat(StringFormatFlags.DirectionVertical);
      _refresh = true;
      _path = new GraphicsPath();
      _move = new Matrix();
    }

    public void DrawGraph(Graphics parGfx, Size parSize)
    {
      if (_size != parSize)
      {
        _size = parSize;
        _refresh = true;
      }
      _gfx = parGfx;
      drawAxes();
      if (_dataList != null)
      {
        drawData();
        drawPosData();
      }
    }

    void drawAxes()
    {
      _pen.Color = Color.Black;
      _pen.Width = 2f;
      _pZero = new PointF(PADL, _size.Height - PADB);
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
          _gfx.DrawString((_scaleMinHeight + i * _multHeight).ToString("0"), _font, Brushes.Black, 15, _pZero.Y - i * _scaleHeight - 10);
        }

        // X Axe
        _maxTime = _dataList.Max(t => t.Datetime);
        _minTime = _dataList.Min(t => t.Datetime);
        _scaleWidth = 0;
        _multWidth = 0;
        while (_scaleWidth <= SCAL * 3)
        {
          if (_multWidth < 5)
            _multWidth += 1;
          else if (_multWidth < 15)
            _multWidth += 5;
          else
            _multWidth *= 2;
          _scaleMinTime = new DateTime((int)(_minTime.Ticks / TimeSpan.TicksPerMinute / _multWidth) * _multWidth * TimeSpan.TicksPerMinute);
          _scaleMaxTime = new DateTime((int)(_maxTime.Ticks / TimeSpan.TicksPerMinute / _multWidth) * _multWidth * TimeSpan.TicksPerMinute);
          if (_scaleMaxTime < _maxTime)
            _scaleMaxTime += new TimeSpan(_multWidth * TimeSpan.TicksPerMinute);
          _scaleWidth = (_size.Width - PADL - PADR) * _multWidth / (int)_scaleMaxTime.Subtract(_scaleMinTime).TotalMinutes;
        }
        for (int i = 0; (int)(_scaleMinTime.Ticks/ TimeSpan.TicksPerMinute) + i * _multWidth <= (int)(_scaleMaxTime.Ticks / TimeSpan.TicksPerMinute) ; i++)
        {
          _gfx.DrawLine(_pen, _pZero.X + i * _scaleWidth, _pZero.Y, _pZero.X + i * _scaleWidth, _pZero.Y + SCAL / 2);
          _gfx.DrawString(new TimeSpan(_scaleMinTime.Ticks + i * _multWidth * TimeSpan.TicksPerMinute).ToString(@"hh\:mm"), _font, Brushes.Black, _pZero.X + i * _scaleWidth - 10, _pZero.Y + 10, _formatVertical);
        }
      }
    }

    void drawData()
    {
      _pen.Color = Color.Blue;
      _pen.Width = 5;
      _dataList = _dataList.OrderBy(o => o.Datetime).ToList();
      if (_dataPoints == null)
        _dataPoints = new List<PointF>();
      _dataPoints.Clear();
      foreach (GPSTrackerData data in _dataList)
      {
        _dataPoints.Add(new PointF(Convert.ToSingle(data.Datetime.Subtract(_scaleMinTime).TotalMinutes * _scaleWidth / _multWidth) + _pZero.X, _pZero.Y - (data.Height - _scaleMinHeight) * _scaleHeight / _multHeight));
      }
      _gfx.DrawLines(_pen, _dataPoints.ToArray());
    }

    public void UpdateData(List<GPSTrackerData> parData)
    {
      _dataList = parData;
    }

    bool hitData()
    {
      if (_dataPoints != null)
      {
        for (_nearestPoint = 0; _mPos.X > _dataPoints.ElementAt(_nearestPoint).X; _nearestPoint++)
        {
          if (_nearestPoint == _dataPoints.Count - 1)
            break;
        }
        if (_nearestPoint > 0 && (_mPos.X - _dataPoints.ElementAt(_nearestPoint - 1).X < _dataPoints.ElementAt(_nearestPoint).X - _mPos.X))
        {
          _nearestPoint--;
        }
        return true;
      }
      return false;
    }

    void drawPosData()
    {
      _pen.Color = Color.Red;
      _pen.Width = 1f;
      if (_refresh)
      {
        _path.Reset();
        _oldPoint = _dataPoints.Count - 1;
        _path.AddLine(_dataPoints.ElementAt(_oldPoint).X, PADT, _dataPoints.ElementAt(_oldPoint).X, _size.Height - PADB);
        _refresh = false;
      }
      _gfx.DrawPath(_pen, _path);
    }

    public void MovePosData(PointF parMPos)
    {
      _mPos = parMPos;
      if (hitData())
      {
        _move.Reset();
        _move.Translate(_dataPoints.ElementAt(_nearestPoint).X - _dataPoints.ElementAt(_oldPoint).X, 0);
        _oldPoint = _nearestPoint;
        _path.Transform(_move);
      }
    }

    public PointF ReturnOffset()
    {
      if (_dataPoints != null)
        return _dataPoints.ElementAt(_oldPoint);
      return PointF.Empty;
    }

    public GPSTrackerData ReturnData()
    {
      if (_dataList != null)
        return _dataList.ElementAt(_oldPoint);
      return GPSTrackerData.Empty;
    }
  }
}
