using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butler : Monster
{
    public Transform roomPosition;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        
    }

    private void Update()
    {
        WalkToPlayer();
    }

    public void WalkToPlayer()
    {
        Vector3 playerPosition = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        this.transform.LookAt(playerPosition);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("walk_1"))
        {
            if (Vector3.Distance(transform.position, playerPosition) > 2)
            {
                transform.Translate(0, 0, 0.03f);
            }
            else
            {
                animator.SetBool("IsCloseToPlayer", true);
            }
        }
    }

    public void LeadToRoom()
    {
        animator.SetBool("IsTalkingFinish", true);
        this.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position, Vector3.back), 0.05f);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("walk_2"))
        {
            if (Vector3.Distance(transform.position, roomPosition.position) > 2)
            {
                transform.Translate(0, 0, 0.03f);
            }
            else
            {
                animator.SetBool("IsCloseToRoom", true);
            }
        }
    }
}
