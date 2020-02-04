using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractGuideController : MonoBehaviour
{
    public TextMeshProUGUI interactGuideText;

    public void SetInteractGuideText(string text)
    {
        interactGuideText.text = text;
    }
}
