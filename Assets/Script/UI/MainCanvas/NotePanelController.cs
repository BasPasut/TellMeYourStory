using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotePanelController : MonoBehaviour
{
    public GameObject notePanel;

    public void SetImageToNote(Sprite noteImage)
    {

        notePanel.GetComponent<Image>().sprite = noteImage;
    }

}
