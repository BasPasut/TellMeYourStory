using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReportPanelController : MonoBehaviour
{
    public Text playerName;
    public Text playerAge;
    public Text playerGender;

    public void Start()
    {
        playerName.text = GameManager.instance.currentPlayerReport.playerName;
        playerAge.text = GameManager.instance.currentPlayerReport.playerAge;
        playerGender.text = GameManager.instance.currentPlayerReport.playerAge;
    }
}
