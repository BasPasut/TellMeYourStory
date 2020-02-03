using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawnController : MonoBehaviour
{

    public List<Transform> spawnPointList;
    public List<GameObject> prefabsList;

    public void Spawn(int triggerIndex)
    {
        Instantiate(prefabsList[triggerIndex], spawnPointList[triggerIndex]);
    }
}
