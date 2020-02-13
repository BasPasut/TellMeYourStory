using UnityEngine;

public class InteractController : MonoBehaviour
{

    public InteractGuideController guideController;
    public NotePanelController notePanelController;

    private void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {

            Debug.Log("Pass");
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        GameObject obj = collision.gameObject;
        if (collision.gameObject.tag == "Interactable")
        {
            guideController.gameObject.SetActive(true);
            if (obj.name.Contains("Door"))
            {
                guideController.SetInteractGuideText("Open");
                if (Input.GetKeyDown(KeyCode.E) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
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
                        if (Input.GetKey(KeyCode.E) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                        {
                            this.GetComponent<OVRPlayerController>().enabled = false;
                            Note note = (Note)item;

                            notePanelController.SetNote(note);
                            notePanelController.gameObject.SetActive(true);

                        }
                        else if (Input.GetKey(KeyCode.Q) || OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
                        {
                            this.GetComponent<OVRPlayerController>().enabled = true;
                            notePanelController.gameObject.SetActive(false);
                        }
                        break;
                    default:
                        break;
                }
                item.GetPerformAction();

            }

        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        //if (collision.gameObject.tag == "Interactable")
        //{
        //    guideController.gameObject.SetActive(true);
        //    if (collision.gameObject.name.Contains("Door"))
        //    {
        //        guideController.SetInteractGuideText("Open");
        //    }             
        //}
    }

    public void OnCollisionStay(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if(collision.gameObject.tag == "Interactable")
        {
            guideController.gameObject.SetActive(true);
            if (obj.name.Contains("Door"))
            {
                guideController.SetInteractGuideText("Open");
                if (Input.GetKeyDown(KeyCode.E) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
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
                        if (Input.GetKey(KeyCode.E) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                        {
                            this.GetComponent<OVRPlayerController>().enabled = false;
                            Note note = (Note)item;
                            
                            notePanelController.SetNote(note);
                            notePanelController.gameObject.SetActive(true);
                            
                        }
                        else if (Input.GetKey(KeyCode.Q) || OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
                        {
                            this.GetComponent<OVRPlayerController>().enabled = true;
                            notePanelController.gameObject.SetActive(false);
                        }
                            break;
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
