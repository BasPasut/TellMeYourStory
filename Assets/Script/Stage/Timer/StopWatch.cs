using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StopWatch : MonoBehaviour
{
    private float currentTime;
    private float startTime;
    private bool isStart;

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            currentTime = Time.time - startTime;
        }
    }

    public void StartTimer()
    {
        isStart = true;
        startTime = Time.time;
    }

    public void StopTimer()
    {
        isStart = false;
    }

    public string GetCurrentTime()
    {
        TimeSpan t = TimeSpan.FromSeconds(currentTime);

        return string.Format("{0:D2}m:{1:D2}s",
                            t.Minutes,
                            t.Seconds);

        /*float minutes = Mathf.Floor(currentTime / 60);
        float seconds = Mathf.Round(currentTime % 60);
        return minutes.ToString("00") + ":" + seconds.ToString("00");*/
    }
}
    
