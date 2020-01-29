using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActionController : MonoBehaviour
{
    GameObject obj;

    public void ReceivedTargetObject(GameObject obj)
    {
        this.obj = obj;
    }

    public void StartTargetAction()
    {
        
    }
}
