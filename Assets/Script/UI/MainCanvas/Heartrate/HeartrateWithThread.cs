using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeartrateWithThread : MonoBehaviour
{
    Thread bpmThread;

    public SerialPort serial = new SerialPort("COM4", 115200);//create new serial port
    public TextMeshProUGUI bpmText;

    public static bool isConnect;

    private bool isReceived;
    private string beat = "0";// string to hols the data in
    private int counter = 0;
    private long sumBeat = 0;
    private int minBeat = int.MaxValue;
    private int maxBeat = int.MinValue;

    void Start()
    {
        isConnect = false;
        OpenConnection();
        // declare thread, and reference sampleFunction
        bpmThread = new Thread(new ThreadStart(ReceivedBPM));
        bpmThread.IsBackground = true;
        // start thread
        bpmThread.Start();
        
    }

    void Update()
    {
        int intBeat = int.Parse(beat);
        if (isReceived == true)
        {
            counter++;
            Debug.Log("BPM :: " + beat);
            bpmText.text = beat;
            sumBeat += intBeat;

            if(intBeat < minBeat)
            {
                minBeat = intBeat;
            }
            if(intBeat > maxBeat)
            {
                maxBeat = intBeat;
            }

            
        }
        
    }

    public float GetAverageBPM()
    {
        float avgBPM = sumBeat / counter;
        float avg = Mathf.Floor(avgBPM);
        return avg;
    }

    public float GetMaxBPM()
    {
        return (float)maxBeat;
    }

    public float GetMinBPM()
    {
        return (float)minBeat;
    }

    public void ReceivedBPM()
    {
        string beatTemp = "0";
        while (bpmThread.IsAlive)
        {
            try
            {
                isReceived = true;
                beat = serial.ReadLine();
                beatTemp = beat;
            }
            catch(TimeoutException e)
            {
                isReceived = false;
                beat = beatTemp;
            }
        }
    }

    private void OnDestroy()
    {
        bpmThread.Abort();
        counter = 0;
        sumBeat = 0;
    }

    public void OpenConnection()
    {

        if (serial != null)
        {
            isConnect = true;
            if (serial.IsOpen)
            {
                serial.Close();
                Debug.Log("Closing port, because it was already open!");
            }
            else
            {
                serial.Open();  // opens the connection
                serial.ReadTimeout = 1000;  // sets the timeout value before reporting error
                Debug.Log("Port Opened!");
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
                isConnect = false;
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
