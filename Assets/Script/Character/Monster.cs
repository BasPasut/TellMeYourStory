using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    Animator animator;


    // Start is called before the first frame update
    protected void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected void TransfromToMonster()
    {
        animator.SetBool("Transform", true);
    }

    protected void StartChasing()
    {
        animator.SetBool("IsSeen", true);
    }

    protected void StopChasing()
    {
        animator.SetBool("IsSeen", false);
    }
}
