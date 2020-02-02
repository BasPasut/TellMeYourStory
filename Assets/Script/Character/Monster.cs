using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    protected Animator animator;


    // Start is called before the first frame update
    protected void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected void TransformToMonster()
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

    protected void StartAttack()
    {
        animator.SetBool("Attack", true);
    }
    protected void StopAttack()
    {
        animator.SetBool("Attack", false);
    }
}
