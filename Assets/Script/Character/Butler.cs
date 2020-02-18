using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butler : Monster
{
    public Transform roomPosition;
    public GameObject player;
    public GameObject smokeParticle;
    public GameObject mutant;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        //StartWalking();
        //Transform();
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("walk_1"))
        {
            WalkToPlayer();
            //TalkingFinish();
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("walk_2"))
        {
            LeadToRoom();
        }
    }

    public void WalkToPlayer()
    {
        Vector3 playerPosition = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        this.transform.LookAt(playerPosition);
        if (Vector3.Distance(transform.position, playerPosition) > 2)
        {
            transform.Translate(0, 0, 0.04f);
        }
        else
        {
            animator.SetBool("IsCloseToPlayer", true);
        }
    }

    public void LeadToRoom()
    {
        TurnRotate(roomPosition, 5f);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("walk_2"))
        {
            if (Vector3.Distance(transform.position, roomPosition.position) > 0.2f)
            {
                transform.Translate(0, 0, 0.03f);
            }
            else
            {
                animator.SetBool("IsCloseToRoom", true);
                TurnRotate(player.transform, 180f);
            }
        }
    }
    public void Transform()
    {
        TransformToMonster();
        Instantiate(smokeParticle, transform.position, transform.rotation);
        Instantiate(mutant, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

    public void StartWalking()
    {
        animator.SetBool("StartWalking", true);
    }

    public void TalkingFinish()
    {
        animator.SetBool("IsTalkingFinish", true);
    }

    private void TurnRotate(Transform target, float angle)
    {
        var lookDirection = target.position - transform.position;
        lookDirection.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation,
        Quaternion.LookRotation(lookDirection), Time.deltaTime * angle);
    }
}
