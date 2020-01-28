using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Note : Item
{
    public int noteIndex;
    public Sprite sprite;

    public void Awake()
    {
        SetPerformAction(ReadNote);
    }

    public void ReadNote()
    {
    }
}
