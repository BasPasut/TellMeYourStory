using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant : Monster
{
    NPCVision mutantVision;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        mutantVision = GetComponentInChildren<NPCVision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mutantVision.GetIsPlayerSeen())
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(mutantVision.GetPlayerTransform().position), 0.1f);
            StartChasing();
            Vector3 playerPosition = mutantVision.GetPlayerPosition();
            Vector3 direction = playerPosition - this.transform.position;
            direction.y = 0;
            transform.LookAt(playerPosition);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("run"))
            {

                //Debug.Log(direction.magnitude);
                transform.LookAt(playerPosition);
                if (direction.magnitude > 1.5)
                {
                    transform.Translate(0, 0, 0.02f);
                }
                else
                {
                    StartAttack();
                }
            }

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
            {
                if(direction.magnitude > 1.5)
                {
                    StopAttack();
                    StartChasing();
                }
            }

           
        }
        else
        {
            StopChasing();
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("turn_left_45"))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(0, 0, 45)),0.02f);
            }
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("turn_right_90"))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(0, 0, -60)), 0.02f);
            }
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
            {
                transform.Translate(0, 0, 0.01f);
            }
        }
    }
}
