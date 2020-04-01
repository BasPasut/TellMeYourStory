using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAttack : MonoBehaviour
{
    public Animator animator;

    private static bool isAttack = false;

    private void OnTriggerEnter(Collider other)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            if (other.gameObject.tag == "Player")
            {
                isAttack = true;
                //End game scene and sound here VEGAN
            }
        }
    }

    public static bool GetIsAttack()
    {
        return isAttack;
    }
}
