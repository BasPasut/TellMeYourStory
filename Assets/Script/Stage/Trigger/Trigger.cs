using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public TriggerType type;
    Transform triggerPoint;
    Action performAction;

    private void Start()
    {
        triggerPoint = this.transform;
        this.gameObject.AddComponent<SphereCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            performAction();
            this.gameObject.SetActive(false);
            
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
