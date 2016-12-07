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
using Android.Bluetooth;

namespace GPS_Tracker_App
{
  [Activity(Label = "ConnectDeviceActivity")]
  public class ConnectDeviceActivity : Activity
  {
    public const string EXTRA_DEVICE_ADDRESS = "device_address";

    Button btnScanDevices;
    ListView lstPaired, lstNew;
    BluetoothAdapter blueAdpt;
    static ArrayAdapter<string> pairedAdpt;
    static ArrayAdapter<string> newAdpt;
    BluetoothReceiver blueRec;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.Bluetooth);
      SetResult(Result.Canceled);

      lstPaired = FindViewById<ListView>(Resource.Id.lstPaired);
      lstNew = FindViewById<ListView>(Resource.Id.lstNew);
      btnScanDevices = FindViewById<Button>(Resource.Id.btnScan);
      pairedAdpt = new ArrayAdapter<string>(this, Resource.Layout.DeviceList);
      newAdpt = new ArrayAdapter<string>(this, Resource.Layout.DeviceList);
      blueAdpt = BluetoothAdapter.DefaultAdapter;

      btnScanDevices.Click += OnBtnScanDevicesClick;
      lstPaired.ItemClick += OnLstClick;
      lstNew.ItemClick += OnLstClick;

      lstPaired.Adapter = pairedAdpt;
      lstNew.Adapter = newAdpt;

      blueRec = new BluetoothReceiver(this);
      IntentFilter filter = new IntentFilter(BluetoothDevice.ActionFound);
      RegisterReceiver(blueRec, filter);
      filter = new IntentFilter(BluetoothAdapter.ActionDiscoveryFinished);
      RegisterReceiver(blueRec, filter);

      if (blueAdpt.BondedDevices.Count > 0)
      {
        foreach (BluetoothDevice blueDevice in blueAdpt.BondedDevices)
          pairedAdpt.Add(blueDevice.Name + "\n" + blueDevice.Address);
      }
      else
      {
        string noDevices = Resources.GetText(Resource.String.NoPairedDevice);
        pairedAdpt.Add(noDevices);
      }
    }

    protected override void OnDestroy()
    {
      base.OnDestroy();
      if (blueAdpt != null)
        blueAdpt.CancelDiscovery();
      UnregisterReceiver(blueRec);
    }

    void OnBtnScanDevicesClick(object sender, EventArgs e)
    {
      (sender as View).Visibility = ViewStates.Gone;
      if (blueAdpt.IsDiscovering)
        blueAdpt.CancelDiscovery();
      blueAdpt.StartDiscovery();
    }

    void OnLstClick(object sender, AdapterView.ItemClickEventArgs e)
    {
      blueAdpt.CancelDiscovery();
      string name = (e.View as TextView).Text.ToString();
      if (name != Resources.GetText(Resource.String.NoNewDevice) && name != Resources.GetText(Resource.String.NoPairedDevice))
      {
        string address = name.Substring(name.Length - 17);
        Intent returnIntent = new Intent();
        returnIntent.PutExtra(EXTRA_DEVICE_ADDRESS, address);
        SetResult(Result.Ok, returnIntent);
        Finish();
      }
    }

    public class BluetoothReceiver : BroadcastReceiver
    {
      Activity _activity;

      public BluetoothReceiver(Activity activity)
      {
        _activity = activity;
      }

      public override void OnReceive(Context context, Intent intent)
      {
        if (intent.Action == BluetoothDevice.ActionFound)
        {
          BluetoothDevice device = (BluetoothDevice)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);
          if (device.BondState != Bond.Bonded)
            newAdpt.Add(device.Name + "\n" + device.Address);
        }
        else if (intent.Action == BluetoothAdapter.ActionDiscoveryFinished)
        {
          if (newAdpt.Count == 0)
          {
            string noDevices = _activity.Resources.GetText(Resource.String.NoNewDevice);
            newAdpt.Add(noDevices);
          }
        }
      }
    }
  }
}