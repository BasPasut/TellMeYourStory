using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public TriggerSpawnController triggerSpawnController;
    public TriggerItemController triggerItemController;
    public TriggerActionController triggerActionController;
    public List<Trigger> triggerPointList;

    private static int currentTriggerIndex;

    // Start is called before the first frame update
    public void Awake()
    {
        currentTriggerIndex = 0;
        for(int i = 0; i < triggerPointList.Count; i++) {
            triggerPointList[i].gameObject.SetActive(false);
            int index = i;
            switch (triggerPointList[i].GetTriggerType())
            {
                case TriggerType.Item:
                    //trigger.SetTriggerAction();
                    break;
                case TriggerType.Spawn:                   
                    triggerPointList[i].PerformActionWithoutObject(() => triggerSpawnController.Spawn(index));
                    //Debug.Log(i);
                    break;
                case TriggerType.Action:
                    triggerActionController.ReceivedTargetObject(triggerPointList[i].PerformActionWithObject(() => triggerActionController.StartTargetAction())); 
                    break;
                default:
                    break;
            }
        }
    }

    private void Update()
    {
        try
        {
            if (currentTriggerIndex <= triggerPointList.Count)
            {
                triggerPointList[currentTriggerIndex].gameObject.SetActive(true);
                if (triggerPointList[currentTriggerIndex].GetIsTrigger())
                {
                    triggerPointList[currentTriggerIndex].gameObject.SetActive(false);
                    currentTriggerIndex++;
                }
            }
        }
        catch(Exception e)
        {
            //Debug.Log(e);        
        }
    }

    public static int GetCurrentTriggerIndex()
    {
        return currentTriggerIndex;
    }
}
