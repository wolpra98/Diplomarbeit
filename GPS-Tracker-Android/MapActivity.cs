using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GPS_Tracker_Android
{
  [Activity(Label = "MapActivity")]
  public class MapActivity : Activity
  {
    Button btnZoom, btnCenter;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.Map);
      
      btnCenter = FindViewById<Button>(Resource.Id.btnCenter);
      btnZoom = FindViewById<Button>(Resource.Id.btnZoom);
      
    }
  }
}