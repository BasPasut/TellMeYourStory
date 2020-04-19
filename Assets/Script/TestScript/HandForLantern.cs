using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class HandForLantern : MonoBehaviour
{
    /*public SteamVR_Action_Boolean pickUpLantern = null;
    private SteamVR_Behaviour_Pose poseBehave = null;
    private FixedJoint joint = null;

    private PickUpLantern pickUplanternInter;
    public List<PickUpLantern> pickUplanternInterContacts = new List<PickUpLantern>();

    private void Awake()
    {
        poseBehave = GetComponent<SteamVR_Behaviour_Pose>();
        joint = GetComponent<FixedJoint>();
    }

    private void Update()
    {
        // Press down
        if (pickUpLantern.GetStateDown(poseBehave.inputSource))
        {
            Debug.Log("trigger down");
            PickUp();
        }

        // Press up
        if (pickUpLantern.GetStateUp(poseBehave.inputSource))
        {
            Debug.Log("trigger up");
            Drop();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("Equipment"))
        {
            return;
        }
        pickUplanternInterContacts.Add(other.gameObject.GetComponent<PickUpLantern>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Equipment"))
        {
            return;
        }
        pickUplanternInterContacts.Remove(other.gameObject.GetComponent<PickUpLantern>());
    }

    public void PickUp()
    {
        pickUplanternInter = GetNearestLantern();
        if (!pickUplanternInter) return;


        if (pickUplanternInter.activeH and)
        {
            pickUplanternInter.activeHand.Drop();
        }
        pickUplanternInter.transform.position = transform.position;
        Rigidbody rigidbody = pickUplanternInter.GetComponent<Rigidbody>();
        joint.connectedBody = rigidbody;
        pickUplanternInter.activeHand = this;
    }

    public void Drop()
    {
        if (!pickUplanternInter) return;
        Rigidbody rigidbody = pickUplanternInter.GetComponent<Rigidbody>();
        rigidbody.velocity = poseBehave.GetVelocity();
        rigidbody.angularVelocity = poseBehave.GetAngularVelocity();
        joint.connectedBody = null;
        pickUplanternInter.activeHand = null;
        pickUplanternInter = null;
    }

    private PickUpLantern GetNearestLantern()
    {
        PickUpLantern nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;

        foreach (PickUpLantern lanternPick in pickUplanternInterContacts)
        {
            distance = (lanternPick.transform.position - transform.position).sqrMagnitude;

            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = lanternPick;
            }
        }

        return nearest;
    }*/
}
