using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace GPS_Tracker
{
  public partial class FormImport : Form
  {
    SerialPort tracker;
    string portName;
    byte[] cmd = new byte[1];
    string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GPS-Tracker", "Import");
    string filename;

    public FormImport()
    {
      InitializeComponent();
    }

    private void OnFormImportShown(object sender, EventArgs e)
    {
      lblText.Text = "Suche GPS-Tracker ...";
      Thread searchDevice = new Thread(SearchDevice);
      searchDevice.Start();
      searchDevice.Join();
      if (portName == null)
      {
        lblText.Text = "GPS-Tracker nicht gefunden";
        Application.DoEvents();
        Thread.Sleep(1000);
        Close();
        return;
      }
      else
      {
        lblText.Text = string.Format("GPS-Tracker Gefunden ({0})", portName);
        CheckDir();
        ImportData();
        lblText.Text = "Abgeschlossen";
      }
      if (tracker.IsOpen)
        tracker.Close();
    }

    void SearchDevice()
    {
      List<SerialPort> ports = new List<SerialPort>();

      foreach (string com in SerialPort.GetPortNames())
      {
        ports.Add(new SerialPort(com, 230400));
      }

      List<Thread> threads = new List<Thread>();

      foreach (SerialPort port in ports)
      {
        Thread thread = new Thread(CheckDevice);
        thread.Start(port);
        threads.Add(thread);
      }
      foreach (Thread thread in threads)
        thread.Join();
      foreach (SerialPort port in ports)
      {
        if (port.PortName == portName)
          tracker = port;
        else
          port.Close();
      }
    }

    void CheckDevice(object obj)
    {
      SerialPort port = (SerialPort)obj;
      port.ReadTimeout = 5000;
      port.WriteTimeout = 5000;
      for (int i = 0; i < 2; i++)
      {
        try
        {
          port.Open();
          port.Write("\0");
          string response = port.ReadLine();
          if (response == "GPS-Tracker")
            portName = port.PortName;
          return;
        }
        catch (Exception e)
        {
          port.BaudRate = 115200;
        }
      }
    }

    void ImportData()
    {
      string name;
      bool skip = false;
      byte[] buffer = new byte[100];
      List<List<byte>> bufferlist = new List<List<byte>>();
      cmd[0] = 0x3;
      try
      {
        tracker.Write(cmd, 0, 1);
        while (true)
        {
          var cc = tracker.ReadChar();
          Debug.WriteLine(cc);
          switch (cc)
          {
            case '#':
              name = tracker.ReadLine() + ".gpst";
              Debug.WriteLine(name);
              filename = Path.Combine(dir, name);
              lblText.Text = string.Format("Lade Daten vom {0}.{1}.20{2}", name.Substring(4, 2), name.Substring(2, 2), name.Substring(0, 2));
              skip = File.Exists(@filename);
              break;
            case '$':
              Array.Clear(buffer, 0, 100);
              for (int i = 0; i < 100; i++)
                buffer[i] = (byte) tracker.ReadByte();
              Debug.WriteLine(string.Join(",",buffer));
              bufferlist.Add(new List<byte>(buffer));
              break;
            case '*':
              if (!skip)
              {
                using (FileStream fs = new FileStream(@filename, FileMode.Create))
                {
                  foreach (List<byte> item in bufferlist)
                      fs.Write(item.ToArray(),0,item.Count);
                }
              }
              break;
            case '+':
              tracker.Close();
              return;
          }
        }
      }
      catch (Exception e)
      {
        lblText.Text = "Fehler bei Übertragung";
        Application.DoEvents();
        Thread.Sleep(1000);
        Close();
      }
    }

    void CheckDir()
    {
      if (!Directory.Exists(@dir))
        Directory.CreateDirectory(@dir);
    }
  }
}
