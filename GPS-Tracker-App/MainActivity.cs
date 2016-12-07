using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Bluetooth;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;

namespace GPS_Tracker_App
{
  [Activity(Label = "GPS_Tracker_App", MainLauncher = true, Icon = "@drawable/icon")]
  public class MainActivity : Activity
  {
    private const int REQUEST_BLUETOOTH = 1;
    private const int REQUEST_CONNECT = 2;
    BluetoothAdapter blueAdpt;
    BluetoothSocket blueSocket;

    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);
      SetContentView(Resource.Layout.Main);

      blueAdpt = BluetoothAdapter.DefaultAdapter;

      if (blueAdpt == null)
      {
        Toast.MakeText(this, "Bluetooth is not available", ToastLength.Long).Show();
        Finish();
        return;
      }

      if (!blueAdpt.IsEnabled)
      {
        Intent enableBlue = new Intent(BluetoothAdapter.ActionRequestEnable);
        StartActivityForResult(enableBlue, REQUEST_BLUETOOTH);
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
        case REQUEST_CONNECT:
          if (resultCode == Result.Ok)
          {
            string address = data.Extras.GetString(ConnectDeviceActivity.EXTRA_DEVICE_ADDRESS);
            BluetoothDevice device = blueAdpt.GetRemoteDevice(address);
            if (device.BondState == Bond.None)
              device.CreateBond();
            //blueSocket = device.CreateRfcommSocketToServiceRecord();
          }
          break;
      }
    }

    public override bool OnCreateOptionsMenu(IMenu menu)
    {
      MenuInflater.Inflate(Resource.Menu.OptionsMenu, menu);
      return base.OnPrepareOptionsMenu(menu);
    }

    public override bool OnOptionsItemSelected(IMenuItem item)
    {
      switch (item.ItemId)
      {
        case Resource.Id.bluetooth:
          Intent connectBlue = new Intent(this, typeof(ConnectDeviceActivity));
          StartActivityForResult(connectBlue, REQUEST_CONNECT);
          return true;
      }
      return false;
    }
  }
}

