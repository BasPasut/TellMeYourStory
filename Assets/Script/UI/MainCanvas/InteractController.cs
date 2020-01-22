using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour
{

    public InstructorController instructorController;
    public InteractGuideController guideController;

    public void OnCollisionEnter(Collision collision)
    { 
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
        if(collision.gameObject.tag == "Interactable")
        {
            guideController.gameObject.SetActive(true);
            if (collision.gameObject.name.Contains("Door"))
            {
                guideController.SetInteractGuideText("Open");
                if (Input.GetMouseButtonDown(0))
                {
                    bool doorStatus = collision.gameObject.GetComponent<Animator>().GetBool("IsOpen");
                    collision.gameObject.GetComponent<Animator>().SetBool("IsOpen", !doorStatus);

                }
            }
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        guideController.gameObject.SetActive(false);
    }
}
