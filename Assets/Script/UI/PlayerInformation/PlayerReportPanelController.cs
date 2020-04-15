using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReportPanelController : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerAge;
    public TextMeshProUGUI playerGender;
    public TextMeshProUGUI time;
    public TextMeshProUGUI avgHeartrate;
    public TextMeshProUGUI maxHeartrate;
    public TextMeshProUGUI minHeartrate;
    public TextMeshProUGUI status;

    public HeartrateWithThread bpm;
    public StopWatch stopWatch;


    public void Start()
    {
        playerName.text = GameManager.instance.currentPlayerReport.playerName;
        playerAge.text = GameManager.instance.currentPlayerReport.playerAge;
        playerGender.text = GameManager.instance.currentPlayerReport.playerGender;
    }

    public void Update()
    {
        time.text = stopWatch.GetCurrentTime();
        avgHeartrate.text = bpm.GetAverageBPM().ToString();
        minHeartrate.text = bpm.GetMinBPM().ToString();
        maxHeartrate.text = bpm.GetMaxBPM().ToString();
    }
}
