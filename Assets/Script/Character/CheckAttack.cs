using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAttack : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            if (other.gameObject.tag == "Player")
            {
                //End game scene and sound here VEGAN
            }
        }
    }
}
