using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractItemController : MonoBehaviour
{

    public InstructorController instructorController;
    public InteractGuideController guideController;

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Interactable")
        {
            guideController.gameObject.SetActive(true);
            if (collision.gameObject.name.Contains("Door"))
            {
                guideController.SetInteractGuideText("Open");
            }             
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        guideController.gameObject.SetActive(false);
    }
}
