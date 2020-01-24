using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActionController : MonoBehaviour
{
    GameObject targetObject;

    public void ReceivedTargetObject(GameObject targetObject)
    {
        this.targetObject = targetObject;
    }

    public void StartTargetAction()
    {

    }
}
