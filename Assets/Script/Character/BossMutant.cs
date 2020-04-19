using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMutant : Monster
{

    GameObject player;
    private AudioSource audioSource;
    

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        player = GameObject.Find("PlayerVR");
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
        Vector3 direction = playerPos - this.transform.position;
        direction.y = 0;

        transform.LookAt(playerPos);
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            transform.LookAt(playerPos);
            if (direction.magnitude >= 5f)
            {
                this.transform.Translate(0, 0, 0.5f);
            }
            else
            {
                ScenarioManager.Instance.LoadGameOver();
            }
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
