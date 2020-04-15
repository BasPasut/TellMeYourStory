using UnityEngine;
using UnityEngine.AI;

public class MutantNavigation : Monster
{
    private NPCVision mutantVision;
    private NavMeshAgent navAgent;

    private float radius = 30f;
    private float timer = 20f;
    private float timer_Count;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        mutantVision = GetComponentInChildren<NPCVision>();
    }

    private void Start()
    {
        base.Start(); 
        timer_Count = timer;
    }

    private void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        timer_Count += Time.deltaTime;
        if (mutantVision.GetIsPlayerSeen())
        {
            StartChasing();
            Vector3 playerPosition = mutantVision.GetPlayerPosition();
            transform.LookAt(playerPosition);
            //Debug.Log(animator.GetCurrentAnimatorStateInfo(0));
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("run"))
            {
                navAgent.SetDestination(playerPosition);
                if (Vector3.Distance(this.transform.position, playerPosition) >= 1.5f)
                {
                    navAgent.isStopped = false;
                 
                }
                else
                {
                    StartAttack();
                    navAgent.isStopped = true;
                }
            }

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
            {
               
                if (Vector3.Distance(this.transform.position, playerPosition) >= 1.5f)
                {
                    StopAttack();
                    StartChasing();
                    navAgent.isStopped = false;
                }
                else
                {
                    navAgent.isStopped = true;
                }
            }
        }
        else
        {
            StopChasing();
            if (timer_Count > timer)
            {
                SetRandomDestination();
                timer_Count = 0f;
            }

            if(navAgent.velocity.sqrMagnitude == 0)
            {
                StopFinding();
            }
            else
            {
                StartFinding();
            }

        }

    }

    void SetRandomDestination()
    {
        Vector3 newDestination = RandomNavSphere(transform.position, radius, -1);
        navAgent.SetDestination(newDestination);
    }

    private Vector3 RandomNavSphere(Vector3 originPos, float dist, int layerMask)
    {
        Vector3 randDir = UnityEngine.Random.insideUnitSphere * dist;
        randDir += originPos;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDir, out navHit, dist, layerMask);

        return navHit.position;

    }
}
