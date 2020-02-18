using UnityEngine;
using Valve.VR;

public class InteractController : MonoBehaviour
{

    public InteractGuideController guideController;
    public NotePanelController notePanelController;

    public SteamVR_Action_Boolean triggerAnimAction;
    public SteamVR_Action_Boolean readNoteAction;
    public SteamVR_Action_Boolean stopReadNoteAction;

    //public void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.gameObject.name);
    //    //if (collision.gameObject.tag == "Interactable")
    //    //{
    //    //    guideController.gameObject.SetActive(true);
    //    //    if (collision.gameObject.name.Contains("Door"))
    //    //    {
    //    //        guideController.SetInteractGuideText("Open");
    //    //    }             
    //    //}
    //}

    public void OnCollisionStay(Collision collision)
    {
        bool triggerDown = triggerAnimAction.GetStateDown(SteamVR_Input_Sources.Any);

        GameObject obj = collision.gameObject;
        if (collision.gameObject.tag == "Interactable")
        {
            guideController.gameObject.SetActive(true);
            if (obj.name.Contains("Door"))
            {
                guideController.SetInteractGuideText("Open");
                if (triggerDown)
                {
                    bool doorStatus = collision.gameObject.GetComponent<Animator>().GetBool("IsOpen");
                    collision.gameObject.GetComponent<Animator>().SetBool("IsOpen", !doorStatus);

                }
            }
            else if (obj.name.Contains("item"))
            {
                Item item = obj.GetComponent<Item>();
                switch (item.itemType)
                {
                    case ItemType.equipment:
                        break;
                    case ItemType.note:
                        guideController.SetInteractGuideText("Read");
                        if (readNoteAction.state)
                        {
                            Debug.Log("true");
                            this.GetComponent<PlayerMovementVR>().enabled = false;
                            Note note = (Note)item;

                            notePanelController.SetNote(note);
                            notePanelController.gameObject.SetActive(true);
                            break;

                        }
                        else
                        {
                            Debug.Log("false");
                            this.GetComponent<PlayerMovementVR>().enabled = true;
                            notePanelController.gameObject.SetActive(false);
                            break;
                        }
                    default:
                        break;
                }
                item.GetPerformAction();

            }

        }
    }

    public void OnCollisionExit(Collision collision)
    {
        guideController.gameObject.SetActive(false);
    }
}
