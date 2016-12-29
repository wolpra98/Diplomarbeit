using Android.App;
using Android.Widget;
using Android.OS;
using Android.Bluetooth;
using System;
using Android.Content;
using Android.Views;
using System.IO;

namespace GPS_Tracker_Android
{
  [Activity(Label = "GPS_Tracker_Android", MainLauncher = true, Icon = "@drawable/icon")]
  public class MainActivity : Activity
  {
    const int REQUEST_BLUETOOTH = 1;
    const int REQUEST_CONNECT = 2;
    static ArrayAdapter<string> dataAdpt;
    BluetoothAdapter blueAdpt;
    BluetoothSocket blueSocket;
    Stream inStream, outStream;
    ListView lstData;
    Button btnSend;
    EditText etSend;

    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);
      SetContentView(Resource.Layout.Main);

      blueAdpt = BluetoothAdapter.DefaultAdapter;
      lstData = FindViewById<ListView>(Resource.Id.lstData);
      btnSend = FindViewById<Button>(Resource.Id.btnSend);
      etSend = FindViewById<EditText>(Resource.Id.etSend);
      dataAdpt = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1);
      lstData.Adapter = dataAdpt;

      btnSend.Click += OnBtnSendClick;
      btnSend.Enabled = false;

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
            Toast.MakeText(this, "Bluetooth enabled!", ToastLength.Short).Show();
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
            blueSocket = device.CreateRfcommSocketToServiceRecord(Java.Util.UUID.FromString("00001101-0000-1000-8000-00805f9b34fb"));
            ConnectToBluetoothDevice();
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
        case Resource.Id.map:
          var geoUri = Android.Net.Uri.Parse("geo:47.091967,15.403134");
          var mapIntent = new Intent(Intent.ActionView, geoUri);
          StartActivity(mapIntent);
          return true;
        case Resource.Id.height:
          //Intent height = new Intent(this, typeof(ConnectDeviceActivity));
          //StartActivity(height);
          return true;
      }
      return false;
    }

    async void ConnectToBluetoothDevice()
    {
      try
      {
        await blueSocket.ConnectAsync();
        inStream = blueSocket.InputStream;
        outStream = blueSocket.OutputStream;
        StartListen();
        btnSend.Enabled = true;
      }
      catch (Exception)
      {
        Toast.MakeText(this, "Can't connect to device!", ToastLength.Short).Show();
      }
    }

    void OnBtnSendClick(object sender, EventArgs e)
    {
      if (etSend.Text != "")
      {
        string text = etSend.Text;
        outStream.Write(System.Text.Encoding.ASCII.GetBytes(text), 0, text.Length);
      }
    }

    void StartListen()
    {
      RunOnUiThread(async () =>
      {
        byte[] byteArr = new byte[1024];
        int bytes = 0;
        while (true)
        {
          try
          {
            bytes += await inStream.ReadAsync(byteArr, bytes, byteArr.Length - bytes);
            string text = System.Text.Encoding.UTF8.GetString(byteArr);
            if (text.IndexOf('\n') > 0)
            {
              dataAdpt.Add(text);
              lstData.SetSelection(lstData.Count - 1);
              Array.Clear(byteArr, 0, byteArr.Length);
              bytes = 0;
            }
          }
          catch (Exception)
          {
            try
            {
              Toast.MakeText(BaseContext, "An Error has occourd! Please reconnect!", ToastLength.Short).Show();
              inStream.Close();
              outStream.Close();
              if (blueSocket.IsConnected)
                blueSocket.Close();
              break;
            }
            catch (Exception)
            {
              Toast.MakeText(BaseContext, "Critical Error!", ToastLength.Short).Show();
              Finish();
              throw;
            }
          }
        }
      });
    }

    protected override void OnDestroy()
    {
      base.OnDestroy();
      inStream.Close();
      outStream.Close();
      if (blueSocket.IsConnected)
        blueSocket.Close();
    }
  }
}

