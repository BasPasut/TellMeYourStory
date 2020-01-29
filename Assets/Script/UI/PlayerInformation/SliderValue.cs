using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    Text ageText;
    // Start is called before the first frame update
    void Start()
    {
        ageText = GetComponent<Text>();
    }

    public void TextUpdate(float value)
    {
        ageText.text = value.ToString();
    }
}
