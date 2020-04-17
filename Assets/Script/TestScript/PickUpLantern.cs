using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Rigidbody))]
public class PickUpLantern : MonoBehaviour
{
    public Hand hand;
    private SphereCollider sphereCol;
    public SteamVR_Action_Boolean pickUpLantern = null;
    private SteamVR_Behaviour_Pose poseBehave = null;

    private void Awake()
    {
        sphereCol = this.GetComponent<SphereCollider>();
        poseBehave = GetComponent<SteamVR_Behaviour_Pose>();
    }

   
}
