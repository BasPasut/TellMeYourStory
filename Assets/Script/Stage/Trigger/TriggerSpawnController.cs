using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawnController : MonoBehaviour
{

    public List<Transform> spawnPointList;
    public List<Monster> monstersList;

    public void Spawn(int triggerIndex)
    {
        Debug.Log(triggerIndex);
        Instantiate(monstersList[0], spawnPointList[0]);
    }
}
