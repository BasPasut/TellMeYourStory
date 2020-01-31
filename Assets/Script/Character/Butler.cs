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

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        this.transform.LookAt(playerPosition);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("walk_1"))
        {
            if (Vector3.Distance(transform.position, playerPosition) > 2) {
                transform.Translate(0, 0, 0.03f);
            }
            else
            {
                animator.SetBool("IsCloseToPlayer", true);
            }
        }
    }
}
