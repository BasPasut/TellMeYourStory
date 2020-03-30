using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReportPanelController : MonoBehaviour
{
    public Text playerName;
    public Text playerAge;
    public Text playerGender;
    public InputField avgHeartrate;
    public InputField maxHeartrate;
    public InputField minHeartrate;
    public InputField status;

    public HeartrateWithThread bpm;


    public void Start()
    {
        playerName.text = GameManager.instance.currentPlayerReport.playerName;
        playerAge.text = GameManager.instance.currentPlayerReport.playerAge;
        playerGender.text = GameManager.instance.currentPlayerReport.playerAge;
    }

    public void Update()
    {
        avgHeartrate.text = bpm.GetAverageBPM().ToString();
        minHeartrate.text = bpm.GetMinBPM().ToString();
        maxHeartrate.text = bpm.GetMaxBPM().ToString();
    }
}
