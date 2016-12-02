using Android.App;
using Android.Widget;
using Android.OS;
using Android.Bluetooth;
using Android.Content;
using Android.Runtime;
using System;

namespace GPS_Tracker_App
{
  [Activity(Label = "GPS_Tracker_App", MainLauncher = true, Icon = "@drawable/icon")]
  public class MainActivity : Activity
  {
    private const int REQUEST_BLUETOOTH = 1;

    BluetoothAdapter blueAdpt = null;
    BluetoothDevice blueDevice;
    Button btnScan;
    ListView lstPaired, lstNew;
    ArrayAdapter pairedAdpt, newAdpt;

    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);
      SetContentView(Resource.Layout.Main);

      blueAdpt = BluetoothAdapter.DefaultAdapter;
      btnScan = FindViewById<Button>(Resource.Id.btnScan);
      lstPaired = FindViewById<ListView>(Resource.Id.lstPaired);
      lstNew = FindViewById<ListView>(Resource.Id.lstNew);

      pairedAdpt = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1);
      newAdpt = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1);

      lstPaired.Adapter = newAdpt;
      lstNew.Adapter = newAdpt;

      btnScan.Click += OnBtnScanClick;
      lstPaired.ItemClick += OnLstDeviceClick;
      lstNew.ItemClick += OnLstDeviceClick;

      if (blueAdpt == null)
        Toast.MakeText(this, "Bluetooth is not available", ToastLength.Long).Show();

      if (!blueAdpt.IsEnabled)
      {
        Intent enableIntent = new Intent(BluetoothAdapter.ActionRequestEnable);
        StartActivityForResult(enableIntent, REQUEST_BLUETOOTH);
      }

      if (blueAdpt.BondedDevices.Count > 0)
      {
        foreach (var device in blueAdpt.BondedDevices)
        {
          pairedAdpt.Add(device.Name + "\n" + device.Address);
        }
      }
      else
      {
        string noDevices = Resources.GetText(Resource.String.NoPairedDevice);
        pairedAdpt.Add(noDevices);
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

    void OnBtnScanClick(object sender, EventArgs e)
    {
      SetProgressBarIndeterminateVisibility(true);
      if (blueAdpt.IsDiscovering)
        blueAdpt.CancelDiscovery();
      blueAdpt.StartDiscovery();
    }

    void OnLstDeviceClick(object sender, AdapterView.ItemClickEventArgs e)
    {
      blueAdpt.CancelDiscovery();
      string address = (e.View as TextView).Text.ToString().Substring((e.View as TextView).Text.ToString().Length - 17);
      blueDevice = blueAdpt.GetRemoteDevice(address);
    }

    protected override void OnDestroy()
    {
      base.OnDestroy();
      if (blueAdpt != null)
        blueAdpt.CancelDiscovery();
    }
  }
}

