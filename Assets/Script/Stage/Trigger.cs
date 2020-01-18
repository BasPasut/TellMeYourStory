using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    Transform triggerPoint;
    TriggerType type;
    Action performAction;

    private void Start()
    {
        triggerPoint = this.transform;   
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            performAction();
        }
    }

    public TriggerType GetTriggerType()
    {
        return type;
    }

    public void SetTriggerAction(Action action)
    {
        this.performAction = action;
    }


}
