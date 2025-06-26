using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ghost : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;
    [SerializeField] Animator anim;
    [SerializeField] float attackDistance = 3;
    float distance;
    bool dead = true;
    
    [SerializeField] float detectionDistance = 100;
    [SerializeField] int damage;

    float timer;
    [SerializeField] float AttackSpeed = 2;

    [SerializeField] float MoveSpeed = 7f;
    [SerializeField] float RunSpeed = 10f;

    [SerializeField] Transform[] WayPoints;
    Transform TargetPoint;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        distance = Vector3.Distance(transform.position, target.position);
        

        if (distance > attackDistance)
        {
            if (distance > detectionDistance)
            {
                agent.speed = MoveSpeed;
                agent.isStopped = false;
                if (TargetPoint == null)
                {
                    TargetPoint = WayPoints[Random.Range(0, WayPoints.Length)];
                    agent.SetDestination(TargetPoint.position);
                }
                else if(Vector3.Distance(transform.position, TargetPoint.position) < 1f)
                {
                    TargetPoint = null;
                }
                anim.SetBool("idle", false);
                anim.SetBool("walk", true);
                anim.SetBool("run", false);
            }
            else //идем к игроку
            {
                agent.isStopped = false;
                agent.speed = RunSpeed;
                agent.SetDestination(target.position);
                TargetPoint = null;
                anim.SetBool("idle", false);
                anim.SetBool("walk", false);
                anim.SetBool("run", true);
            }
        }
        else
        {
            agent.isStopped = true;
            if (timer > AttackSpeed)
            {
                timer = 0;
                //player.Damage
                anim.SetTrigger("attack");
            }
            anim.SetBool("idle", false);
            anim.SetBool("walk", false);
            anim.SetBool("run", false);
        }
    }
}