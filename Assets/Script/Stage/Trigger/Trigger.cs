using System;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public TriggerType triggerType;

    public Item obj;

    Transform triggerPoint;
    Action performAction;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Character")
        {
            performAction();
            this.gameObject.SetActive(false);
            isTrigger = true;
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

    public Item PerformActionWithItem(Action action)
    {
        Debug.Log(obj.name);
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