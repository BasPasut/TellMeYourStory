using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractGuideController : MonoBehaviour
{
    public Text interactGuideText;

    public void SetInteractGuideText(string text)
    {
        interactGuideText.text = text;
    }
}
