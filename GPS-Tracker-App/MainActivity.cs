using Android.App;
using Android.Widget;
using Android.OS;
using Android.Bluetooth;
using Android.Content;
using Android.Runtime;

namespace GPS_Tracker_App
{
  [Activity(Label = "GPS_Tracker_App", MainLauncher = true, Icon = "@drawable/icon")]
  public class MainActivity : Activity
  {
    private const int REQUEST_BLUETOOTH = 1;

    BluetoothAdapter blue = null;

    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);
      SetContentView(Resource.Layout.Main);

      blue = BluetoothAdapter.DefaultAdapter;
      if (blue == null)
        Toast.MakeText(this, "Bluetooth is not available", ToastLength.Long).Show();

      if (!blue.IsEnabled)
      {
        Intent enableIntent = new Intent(BluetoothAdapter.ActionRequestEnable);
        StartActivityForResult(enableIntent, REQUEST_BLUETOOTH);
      }
    }

    protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
    {
      switch (requestCode)
      {
        case REQUEST_BLUETOOTH:
          if (resultCode == Result.Ok)
            Toast.MakeText(this, "Bluetooth ok!", ToastLength.Short).Show();
          else
            Toast.MakeText(this, "Bluetooth not enabled!", ToastLength.Short).Show();
          break;
      }
    }
  }
}

