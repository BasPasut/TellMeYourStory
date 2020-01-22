using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class NPCVision : MonoBehaviour
{
    public float range = 10;
    public float angleRange = 45;
    public int resolution = 10;

    [SerializeField]
    private List<GameObject> seeingObj = new List<GameObject>();
    [SerializeField]
    private List<GameObject> seeingPlayer = new List<GameObject>();

    private GameObject player;
    private bool IsPlayerSeen;
    private Vector3 playerPosition;

    float angle = 0;

    void Update()
    {
        //seeingObj.Clear();
        seeingPlayer.Clear();
        for (int i = 0; i < resolution; i++)
        {
            for (int j = -1; j <= 1; j += 2)
            {
                int oldListLen = seeingObj.Count;
                bool[] existListHash = new bool[oldListLen];

                angle = angleRange / resolution * i * j;
                Ray ray = new Ray(transform.position, new Vector3(Mathf.Sin((angle + transform.eulerAngles.y) * Mathf.Deg2Rad), 0, Mathf.Cos((angle + transform.eulerAngles.y) * Mathf.Deg2Rad)));
                RaycastHit hitData;

                if (Physics.Raycast(ray, out hitData, range))
                {
                    //if (hitData.collider.gameObject != gameObject)
                    //    if (!seeingObj.Contains(hitData.collider.gameObject))
                    //        seeingObj.Add(hitData.collider.gameObject);
                    if (hitData.collider.gameObject.tag == "Player")
                    {
                        if (!seeingPlayer.Contains(hitData.collider.gameObject))
                            seeingPlayer.Add(hitData.collider.gameObject);
                    }
                    
                }
                try
                {
                    if (seeingPlayer.Count > 0)
                    {
                        Debug.Log("see");
                        IsPlayerSeen = true;
                        playerPosition = new Vector3(seeingPlayer[0].gameObject.transform.position.x, 0, seeingPlayer[0].gameObject.transform.position.z);
                    }
                    else
                    {
                        Debug.Log("not see");
                        IsPlayerSeen = false;
                    }
                }
                catch(Exception e)
                {

                }
            }           
        }

    }

    void OnDrawGizmosSelected()
    {
        for (int i = 0; i < resolution; i++)
        {
            for (int j = -1; j <= 1; j += 2)
            {
                angle = angleRange / resolution * i * j;
                Gizmos.color = Color.yellow;
                Gizmos.DrawRay(transform.position, range * new Vector3(Mathf.Sin((angle + transform.eulerAngles.y) * Mathf.Deg2Rad), 0, Mathf.Cos((angle + transform.eulerAngles.y) * Mathf.Deg2Rad)));
            }
        }
    }

    public bool GetIsPlayerSeen()
    {
        return IsPlayerSeen;
    }

    public Vector3 GetPlayerPosition()
    {
        return playerPosition;
    }
    
}

