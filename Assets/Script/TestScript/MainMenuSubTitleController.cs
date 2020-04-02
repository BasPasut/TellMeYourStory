using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuSubTitleController : MonoBehaviour
{
    public TextMeshProUGUI subTextBox;
    private float timeToHint = Time.time;

    private void Start()
    {
        timeToHint = 0;
        StartCoroutine(PlaySub());
    }

    private void Update()
    {
        timeToHint += Time.deltaTime;
        if (timeToHint >= 60)
        {
            timeToHint = 0;
            StartCoroutine(ShowHintToAFK());
        }
    }

    IEnumerator PlaySub()
    {
        //yield return new WaitForSeconds();
        subTextBox.GetComponent<TextMeshProUGUI>().text = "Oh, you finally awake!";
        yield return new WaitForSeconds(1.5f);
        subTextBox.GetComponent<TextMeshProUGUI>().text = "Would you kindly tell me what happen to you? Please point at the check box.";
        yield return new WaitForSeconds(5);
        subTextBox.GetComponent<TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(8);
        StartCoroutine(PlayHint());
    }

    IEnumerator PlayHint()
    {
        subTextBox.GetComponent<TextMeshProUGUI>().text = "Hello?";
        yield return new WaitForSeconds(1);
        subTextBox.GetComponent<TextMeshProUGUI>().text = "Are you okay?";
        yield return new WaitForSeconds(1);
        subTextBox.GetComponent<TextMeshProUGUI>().text = "Can you point or swipe at the check box?";
        yield return new WaitForSeconds(4f);
        subTextBox.GetComponent<TextMeshProUGUI>().text = "";
    }

    IEnumerator ShowHintToAFK()
    {
        subTextBox.GetComponent<TextMeshProUGUI>().text = "Doctor?";
        yield return new WaitForSeconds(1);
        subTextBox.GetComponent<TextMeshProUGUI>().text = "Hello?";
        yield return new WaitForSeconds(1);
        subTextBox.GetComponent<TextMeshProUGUI>().text = "Why he sit idle like that?";
        yield return new WaitForSeconds(1.5f);
        subTextBox.GetComponent<TextMeshProUGUI>().text = "It seems there are 2 check boxes: Yes to start the game, No to close the game. I see.";
        yield return new WaitForSeconds(5);
        subTextBox.GetComponent<TextMeshProUGUI>().text = "Let's choose one.";
        yield return new WaitForSeconds(2);
        subTextBox.GetComponent<TextMeshProUGUI>().text = "";
    }
}
