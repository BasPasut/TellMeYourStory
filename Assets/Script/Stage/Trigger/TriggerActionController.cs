using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActionController : MonoBehaviour
{
    Item item;

    public void ReceivedTargetObject(Item item)
    {
        this.item = item;
    }

    public void StartTargetAction()
    {
        item.GetPerformAction().Invoke();
    }
}
