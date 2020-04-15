using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMutant : Monster
{

    public GameObject player;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RunningToPlayer();
    }

    void RunningToPlayer()
    {
        Vector3 playerPos = player.transform.position;
        playerPos.y = this.transform.position.y;
        if(this.animator.GetCurrentAnimatorStateInfo(0).IsName("roaring"))
        {
            this.transform.LookAt(playerPos);
            if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("run"))
                this.transform.Translate(0, 0, 0.05f);
        }
    }

    void PlayRoar() {
       // audioSource.PlayOneShot();
    }

    void PlayRun()
    {
        //audioSource.PlayOneShot();
    }
}
