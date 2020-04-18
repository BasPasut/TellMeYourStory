using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType itemType;

    public Action GetPerformAction()
    {
        Debug.Log(itemType);
        if (itemType == ItemType.doorUnder)
        {
            return UnlockDoor;
        }
        else if (itemType == ItemType.piano)
        {
            return PlayPianoSound;
        }
        else
        {
            return null;
        }

    }

    private void PlayPianoSound()
    {
        Debug.Log("Play piano sound");
        SoundManager.PlaySound(Sound.Piano, new Vector3(-10.8f, 1.15f, -17.06f));
    }

    private void UnlockDoor()
    {
        Debug.Log("Unlock the door");
        this.gameObject.tag = "Interactable";
    }
}