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

    private void Awake()
    {
        canvasFader.FadeOut();
    }

    private void Update()
    {
        if (SteamVR_Actions._default.GrabPinch.GetStateDown(SteamVR_Input_Sources.LeftHand) ||
            SteamVR_Actions._default.GrabPinch.GetStateDown(SteamVR_Input_Sources.RightHand) || Input.GetMouseButtonDown(0))
        {
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
