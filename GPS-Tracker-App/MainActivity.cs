﻿using System;
using System.IO;
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
      dataAdpt = new ArrayAdapter<string>(this, Resource.Layout.DeviceList);
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
        byte[] text = new byte[1024];
        int bytes;
        while (true)
        {
          try
          {
            bytes = await inStream.ReadAsync(text, 0, text.Length);
            if (bytes > 0)
            {
              dataAdpt.Add(System.Text.Encoding.ASCII.GetString(text));
              lstData.SetSelection(lstData.Count - 1);
              Toast.MakeText(BaseContext, "ok", ToastLength.Short).Show();
            }
            else
            {
              Toast.MakeText(BaseContext, "End", ToastLength.Short).Show();
            }
          }
          catch (Exception)
          {
            Toast.MakeText(BaseContext, "Input Error", ToastLength.Short).Show();
          }
        }
      });
    }
  }
}

