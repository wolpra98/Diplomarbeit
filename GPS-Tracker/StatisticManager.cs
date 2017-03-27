using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS_Tracker
{
  class StatisticManager
  {
    List<GPSTrackerData> data;
    List<GPSTrackerData> dataAll;
    List<int> dataOutOfRange;


    public List<GPSTrackerData> Data
    {
      get
      {
        return data;
      }

      set
      {
        reset();
        data = filter(value);
        dataAll = data;
        if (data.Count != 0)
          calculate();
      }
    }
    public const int sample = 10;
    public float Distance;
    public float RealDistence;
    public float HeightDifference;
    public float HeightDistance;
    public float HeightMin;
    public float HeightMax;
    private float oldHeight = 0;
    private float offset;


    public StatisticManager() { }

    public void SetRange(DateTime minTime, DateTime maxTime)
    {
      reset();
      data = dataAll;
      dataOutOfRange.Clear();
      for (int i = 0; i < data.Count - 1; i++)
      {
        if (data[i].Datetime < minTime)
          dataOutOfRange.Add(i);
        if (data[i].Datetime > maxTime)
          dataOutOfRange.Add(i);
      }
      dataOutOfRange.Sort();
      dataOutOfRange.Reverse();
      if (dataOutOfRange.Count != 0)
        foreach (int id in dataOutOfRange)
          data.RemoveAt(id);
      if (data.Count != 0)
        calculate();
    }

    List<GPSTrackerData> filter(List<GPSTrackerData> data)
    {
      for (int i = data.Count - 1; i >= 0; i--)
      {
        if (!data[i].IsValid)
          data.RemoveAt(i);
      }
      offset = data.Average(t => t.Offset);
      if (data.Count <= sample)
        return data;
      List<GPSTrackerData> dataFiltered = new List<GPSTrackerData>();
      List<GPSTrackerData> buffer = data.GetRange(0, sample - 1);
      for (int i = sample - 1; i < data.Count; i++)
      {
        buffer.Add(data.ElementAt(i));
        dataFiltered.Add(calcMid(buffer));
        buffer.RemoveAt(0);
      }
      return dataFiltered;
    }

    void calculate()
    {
      float heigthDif, distDif;
      HeightMin = data.Min(t => t.Height);
      HeightMax = data.Max(t => t.Height);
      HeightDifference = HeightMax - HeightMin;
      HeightDistance = 0;
      for (int i = 1; i < data.Count; i++)
      {
        heigthDif = Math.Abs(data.ElementAt(i).Height - data.ElementAt(i - 1).Height);
        HeightDistance += heigthDif;
        distDif = calcDist(data.ElementAt(i), data.ElementAt(i - 1));
        Distance += distDif;
        RealDistence += Convert.ToSingle(Math.Sqrt(distDif * distDif + heigthDif * heigthDif));
      }
    }

    GPSTrackerData calcMid(List<GPSTrackerData> buffer)
    {
      GPSTrackerData midPoint = new GPSTrackerData();
      float height = 0, lat = 0, lng = 0;
      height = buffer.Average(t => t.Height) + offset;
      lat = buffer.Average(t => t.Lat);
      lng = buffer.Average(t => t.Lng);
      if ((int)(height + 0.75f) < oldHeight || (int)(height + 0.25f) > oldHeight)
        oldHeight = (int)(height + 0.5f);
      midPoint.Height = oldHeight;
      midPoint.GPSData(lng, lat);
      midPoint.Datetime = new DateTime(Convert.ToInt64(buffer.Average(t => t.Datetime.Ticks) + 0.5));
      return midPoint;
    }

    float calcDist(GPSTrackerData point1, GPSTrackerData point2)
    {
      double r = 6371000.785;
      double p1 = point1.Lat * Math.PI / 180.0f;
      double p2 = point2.Lat * Math.PI / 180.0f;
      double dp = (point2.Lat - point1.Lat) * Math.PI / 180.0f;
      double dl = (point2.Lng - point1.Lng) * Math.PI / 180.0f;

      double a = Math.Sin(dp / 2) * Math.Sin(dp / 2) + Math.Cos(p1) * Math.Cos(p2) * Math.Sin(dl / 2) * Math.Sin(dl / 2);
      double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
      return Convert.ToSingle(r * c);
    }

    void reset()
    {
      Distance = 0;
      RealDistence = 0;
      HeightDifference = 0;
      HeightDistance = 0;
      HeightMin = 0;
      HeightMax = 0;
      oldHeight = 0;
      offset = 0;
      dataOutOfRange = new List<int>();
    }
  }
}
