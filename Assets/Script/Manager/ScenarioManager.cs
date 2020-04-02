using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using TMPro;

public class ScenarioManager : MonoBehaviour
{
    public static ScenarioManager Instance { get; private set; }

    private StopWatch timer;
    private SwapFloor swapFloor;
    public CanvasFader canvasFader;
    public TextMeshProUGUI subTextBox;

    public Transform gameoverPos;
    public GameObject player;
    public GameObject gameOverRoom;
    public GameObject resultSheet;

    public string mainMenuScene;
    public Canvas loadingImg;

    public SteamVR_Action_Boolean triggerAnimAction;

    private bool isGameOver;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        timer = this.GetComponent<StopWatch>();
        swapFloor = this.GetComponent<SwapFloor>();
        isGameOver = false;
        canvasFader.FadeOut();
        timer.StartTimer();
    }

    private void Update()
    {
        //bool triggerDown = triggerAnimAction.GetStateDown(SteamVR_Input_Sources.Any);

        if (Input.GetKeyDown(KeyCode.End))
        {
            LoadGameOver();
        }
        else if (isGameOver == true)
        {
            if (Input.GetMouseButtonDown(0) /*|| triggerDown*/)
            {
                canvasFader.FadeIn();
                LoadMainMenuScene();
            }
        }
    }

    public void LoadGameOver()
    {
        isGameOver = true;
        timer.StopTimer();
        canvasFader.FadeIn();
        StartCoroutine(ChangeScenario());
    }

    public void OpenUnderGround()
    {
        swapFloor.OpenUnderground();
    }

    IEnumerator ChangeScenario()
    {
        yield return new WaitForSeconds(3);
        swapFloor.CloseMansion();
        gameOverRoom.SetActive(true);
        player.transform.position = gameoverPos.position;
        canvasFader.FadeOut();
        resultSheet.SetActive(true);
        subTextBox.GetComponent<TextMeshProUGUI>().text = "Press Trigger to continue";
    }

    public void LoadMainMenuScene()
    {
        canvasFader.FadeOut();
        loadingImg.gameObject.SetActive(true);
        SceneManager.LoadScene(mainMenuScene, LoadSceneMode.Single);
        Destroy(this);
    }
}
