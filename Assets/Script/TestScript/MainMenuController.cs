using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Collider yesButton;
    public Collider noButton;

    public Canvas loadingCanvas;

    public CanvasFader canvasFader;

    public void Awake()
    {
        canvasFader.FadeOut();
    }

    private void Update()
    {
        if (yesButton.isTrigger == true )
        {
            canvasFader.FadeIn();
            loadingCanvas.gameObject.SetActive(true);
            YesButtonClick();
        }
        else if (noButton.isTrigger == true)
        {
            NoButtonClick();
        }
    }

    public void YesButtonClick()
    {
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
        Destroy(this);
    }

    public void NoButtonClick()
    {
        Debug.Log("No");
    }
}
