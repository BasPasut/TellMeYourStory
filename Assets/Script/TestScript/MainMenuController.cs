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
    public GameObject loadingRoom;
    public GameObject mainMenuRoom;
    public GameObject playerModel;
    public Transform playerWaitingRoom;

    public void Awake()
    {
        canvasFader.FadeOut();
    }

    public void Start()
    {
        sittingAnim = GetComponent<Animator>();
        sittingAnim.Play("Sit", 0);
        loadingRoom.SetActive(false);
    }

    private void Update()
    {
        if (yesButton.isTrigger == true)
        {
            canvasFader.FadeIn();
            loadingRoom.SetActive(true);
            playerModel.transform.position = playerWaitingRoom.position;
            playerModel.transform.rotation = playerWaitingRoom.rotation;
            mainMenuRoom.SetActive(false);
            StartCoroutine(Wait());
        }
        else if (noButton.isTrigger == true)
        {
            canvasFader.FadeIn();
            NoButtonClick();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            canvasFader.FadeIn();
            loadingRoom.SetActive(true);
            playerModel.transform.position = playerWaitingRoom.position;
            playerModel.transform.rotation = playerWaitingRoom.rotation;
            mainMenuRoom.SetActive(false);
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4f);
        YesButtonClick();
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
