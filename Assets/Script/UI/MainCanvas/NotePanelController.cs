using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotePanelController : MonoBehaviour
{
    Note note;
    public GameObject notePanel;

    public void Start()
    {
        SetImageToNote();
    }

    void SetImageToNote()
    {

        notePanel.GetComponent<Image>().sprite = note.sprite;
    }

    public void SetNote(Note note)
    {
        this.note = note;
    }
}
