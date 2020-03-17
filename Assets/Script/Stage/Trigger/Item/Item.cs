using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType itemType;

    public Action GetPerformAction()
    {
        switch (itemType)
        {
            case ItemType.piano:
                return PlayPianoSound;
            default:
                return null;
        }
       
    }

    private void PlayPianoSound()
    {
        SoundManager.PlaySound(Sound.Piano, this.transform.position);
    }
}
