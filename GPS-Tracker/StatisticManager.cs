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
    List<GPSTrackerData> dataRaw;


    public List<GPSTrackerData> Data
    {
      get
      {
        return data;
      }

      set
      {
        dataRaw = value;
        data = filter(value);
        if (data.Count != 0)
          calculate();
      }
    }
    public float Distance;
    public float RealDistence;
    public float HeightDifference;
    public float HeightDistance;
    public float HeightMin;
    public float HeightMax;


    public StatisticManager() { }


    List<GPSTrackerData> filter(List<GPSTrackerData> data)
    {
      for (int i = data.Count - 1; i >= 0; i--)
      {
        if (!data[i].IsValid)
          data.RemoveAt(i);
      }
      if (data.Count <= 10)
        return data;
      List<GPSTrackerData> dataFiltered = new List<GPSTrackerData>();
      List<GPSTrackerData> buffer = data.GetRange(0, 9);
      for (int i = 9; i < data.Count; i++)
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
      }
    }

    GPSTrackerData calcMid(List<GPSTrackerData> buffer)
    {
      GPSTrackerData midPoint = new GPSTrackerData();
      float height = 0, lat = 0, lng = 0;
      foreach (GPSTrackerData item in buffer)
      {
        height += item.Height;
        lat += item.Lat;
        lng += item.Lng;
      }
      midPoint.Height = height / 10.0f;
      midPoint.GPSData(lng / 10.0f, lat / 10.0f);
      midPoint.Datetime = buffer.Last().Datetime;
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
  }
}
