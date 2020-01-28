using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class HeartrateWithThread : MonoBehaviour
{
    Thread bpmThread;

    public SerialPort serial = new SerialPort("COM3", 115200);//create new serial port
    public Text bpmText;

    private string beat = "0";// string to hols the data in

    void Start()
    {
        OpenConnection();
        // declare thread, and reference sampleFunction
        bpmThread = new Thread(new ThreadStart(ReceivedBPM));
        bpmThread.IsBackground = true;
        // start thread
        bpmThread.Start();
        
    }

    void Update()
    {
        // the variable data (see above) can now be manipulated and used
        bpmText.text = beat;
    }

    public void ReceivedBPM()
    {
        while (bpmThread.IsAlive)
        {
            // execute operation
            // for example:
            try
            {
                beat = serial.ReadLine();
            }
            catch(TimeoutException e)
            {
                beat = "0";
            }
        }
    }

    public void OpenConnection()
    {

        if (serial != null)
        {
            if (serial.IsOpen)
            {
                serial.Close();
                Debug.Log("Closing port, because it was already open!");
                //message = “Closing port, because it was already open!”;
            }
            else
            {
                serial.Open();  // opens the connection
                serial.ReadTimeout = 1000;  // sets the timeout value before reporting error
                Debug.Log("Port Opened!");
                //        message = “Port Opened!”;
            }
        }
        else
        {
            if (serial.IsOpen)
            {
                print("Port is already open");

            }
            else
            {
                print("Port == null");
            }
        }
    }

    public string GetStrBPM()
    {
        return beat;
    }

    public int GetIntBPM()
    {
        return int.Parse(beat);
    }
}
