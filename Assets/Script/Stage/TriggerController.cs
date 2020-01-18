using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{

    public TriggerSpawnController triggerSpawnController;
    public TriggerItemController triggerItemController;
    public List<Trigger> triggerPointList;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < triggerPointList.Count; i++) { 
            switch (triggerPointList[i].GetTriggerType())
            {
                case TriggerType.Item:
                    //trigger.SetTriggerAction();
                    break;
                case TriggerType.Spawn:
                    triggerPointList[i].SetTriggerAction(() => triggerSpawnController.Spawn(i));
                    break;
                default:
                    break;
            }
        }
    }

    
}
