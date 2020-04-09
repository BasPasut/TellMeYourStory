using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Collider yesButton;
    public Collider noButton;

    public Animator sittingAnim;

    public Canvas loadingCanvas;

    public CanvasFader canvasFader;

    public void Awake()
    {
        canvasFader.FadeOut();
    }

    public void Start()
    {
        sittingAnim = GetComponent<Animator>();
        sittingAnim.Play("Sit", 0);
    }

    private void Update()
    {
        if (yesButton.isTrigger == true)
        {
            canvasFader.FadeIn();
            StartCoroutine(Wait());
            loadingCanvas.gameObject.SetActive(true);
            YesButtonClick();
        }
        else if (noButton.isTrigger == true)
        {
            canvasFader.FadeIn();
            StartCoroutine(Wait());
            NoButtonClick();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            canvasFader.FadeIn();
            StartCoroutine(Wait());
            loadingCanvas.gameObject.SetActive(true);
            YesButtonClick();
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
    }

    public void YesButtonClick()
    {
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
        Destroy(this);
    }

    public void NoButtonClick()
    {
        Debug.Log("No");

        Application.Quit();
    }
}
