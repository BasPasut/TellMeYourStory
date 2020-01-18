using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructorController : MonoBehaviour
{

    public Text instructorText;

    public void SetInstructorText(string text)
    {
        instructorText.text = text;
    }

    
}
