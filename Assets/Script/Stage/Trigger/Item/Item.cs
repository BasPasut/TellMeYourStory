using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType itemType;
    private Action performAction;

    public void SetPerformAction(Action performAction)
    {
        this.performAction = performAction;
    }

    public Action GetPerformAction()
    {
        return performAction;
    }
}
