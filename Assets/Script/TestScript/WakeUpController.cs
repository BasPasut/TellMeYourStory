using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class WakeUpController : MonoBehaviour
{
    public string mainMenuScene;
    public Canvas loadingImg;
    public CanvasFader canvasFader;

    public SteamVR_Action_Boolean triggerAnimAction;

    private void Awake()
    {
        //canvasFader.FadeIn();
        canvasFader.FadeOut();
    }

    private void Update()
    {
        bool triggerDown = triggerAnimAction.GetStateDown(SteamVR_Input_Sources.Any);
        if (triggerDown || Input.GetMouseButtonDown(0))
        {
            //canvasFader.FadeOut();
            canvasFader.FadeIn();
            LoadMainMenuScene();
        }
    }

    private void LoadMainMenuScene()
    {
        loadingImg.gameObject.SetActive(true);
        SceneManager.LoadScene(mainMenuScene, LoadSceneMode.Single);
        Destroy(this);
    }
}
