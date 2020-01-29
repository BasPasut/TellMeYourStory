using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInformationController : MonoBehaviour
{
    public Text playerName;
    public Text playerAge;
    public Dropdown playerGender;
    public Button submit;
    public GameObject playerReportPanel;

    private void Start()
    {
        submit.onClick.AddListener(() => SubmitPlayerInform());
    }

    public void SubmitPlayerInform()
    {
        if (playerName.text != "" && playerAge.text != null && playerGender.captionText != null)
        {
            Debug.Log(playerName.text);
            GameManager.instance.currentPlayerReport.SetPlayerBasicInform(playerName.text, playerAge.text, playerGender.captionText.text);
            SceneManager.LoadScene("GameplayBas", LoadSceneMode.Single);
        }
    }
}
