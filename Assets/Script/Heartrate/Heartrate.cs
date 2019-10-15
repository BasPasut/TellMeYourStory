using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.IO;
using UnityEngine.UI;
using System;

public class Heartrate : MonoBehaviour
{
    public SerialPort serial = new SerialPort("COM3", 9600);//create new serial port
    private string beat = "0";// string to hols the data in
    private List<int> beatPM = new List<int>(); //List to hold the beats

    public Text heartrateMonitor;

    void Start()
    {
        //open a new connection
        OpenConnection();
    }

    void Update()
    {
        beat = "";
        //Read data input … should be a letter to start (char)
        //then 3 numbers and then carriage return
        try
        {
            beat = serial.ReadLine();
        }
        catch(TimeoutException e)
        {
            beat = "0";
        }

        //        print (beat);
        //Create an int that can be used by the Client
        //int somethingToSend = AnalyseBeats(beat);
        heartrateMonitor.text = beat;

    }

    void OnApplicationQuit()
    {
        serial.Close();
    }

    //Function connecting to Arduino
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
    int AnalyseBeats(string str)
    {
        //Data comes in with a “S” header, a “Q” header or a “B” header
        //S = raw data .. “Q” is (allegedly) the time since the last beat was detected
        //and B is the one that we want.  It is the beats per minute averaged over 10 beats

        if (str.StartsWith("B"))
        {
            //            print (“Original data.” + str);
            //create a new string
            string t = null;
            //append to t everything except the starting letter
            for (int j = 1; j < str.Length; ++j)
            {
                t += str[j];
            }
            //Convert that string into an int
            int temp = int.Parse(t);
            //            print (“Modified data.” + temp);
            //add that int to the list
            beatPM.Add(temp);

        }
        //        print (“BMP.count.” + beatPM.Count);

        //Create an average of the BPM to give a more stable reading of the current pulse rate
        if (beatPM.Count >= 5)
        {
            int bAv = 0;
            for (int i = 0; i < beatPM.Count; ++i)
            {
                bAv += beatPM[i];
            }
            bAv = (int)bAv / beatPM.Count;
            //            Debug.Log(“Average over last 5 beats = ” + bAv);
            beatPM.RemoveAt(0);
            return bAv;
        }

        return 0;
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


