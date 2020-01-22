using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public TriggerType type;
    Transform triggerPoint;
    Action performAction;

    private bool IsTrigger;

    private void Start()
    {
        IsTrigger = false;
        triggerPoint = this.transform;
        this.gameObject.AddComponent<SphereCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            performAction();
            this.gameObject.SetActive(false);
            IsTrigger = true;
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

    public bool GetIsTrigger()
    {
        return IsTrigger;
    }

    public void DestroyTriggerPoint()
    {
        Destroy(this);
    }

}
