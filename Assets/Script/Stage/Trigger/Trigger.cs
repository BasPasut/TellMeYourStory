using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Trigger : MonoBehaviour
{
    public TriggerType triggerType;
    public GameObject obj;

    Transform triggerPoint;
    Action performAction;

    bool testBool;


    private bool isTrigger;

    protected void Start()
    {
        isTrigger = false;
        triggerPoint = this.transform;
        if (TriggerController.GetCurrentTriggerIndex() == 0)
        {
            CapsuleCollider trigger = this.gameObject.AddComponent<CapsuleCollider>();
            trigger.isTrigger = true;
            trigger.direction = 2;
        }
        else
        {
            this.gameObject.AddComponent<SphereCollider>().isTrigger = true;
        }
    }

    private void OnValidate()
    {
        if (triggerType != TriggerType.Action)
        {
            obj = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Character")
        {
            if (triggerType == TriggerType.Spawn || triggerType == TriggerType.Timeline)
            {
                performAction();
                this.gameObject.SetActive(false);
                isTrigger = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (triggerType == TriggerType.Action)
            {
                performAction();
                this.gameObject.SetActive(false);
                isTrigger = true;
            }
        }
    }

    public TriggerType GetTriggerType()
    {
        return triggerType;
    }

    public void SetIsTrigger(bool isTrigger)
    {
        this.isTrigger = isTrigger;
    }

    public void PerformActionWithoutObject(Action action)
    {
        performAction = action;
    }

    public GameObject PerformActionWithItem(Action action)
    {
        performAction = action;
        return obj;
    }

    public void SetTriggerAction(Action action)
    {
        this.performAction = action;
    }

    public bool GetIsTrigger()
    {
        return isTrigger;
    }

    public void DestroyTriggerPoint()
    {
        Destroy(this);
    }

}
