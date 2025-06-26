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
    [SerializeField] protected float attackDistance = 3;
    protected float distance;
    bool dead = true;
    protected GameObject player;
    [SerializeField] float detectionDistance = 20;
    [SerializeField] protected int damage;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<plaer>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);

        //��������� ����� ���� � ���������� ������
        distance = Vector3.Distance(transform.position, player.transform.position);
        

        float closestDistance = Mathf.Infinity;
        if (distance > attackDistance)
        {

        }


    }


    public virtual void Move()
    {
        //���� ���������� ����� ������ � ������� ������, ��� ������ �����������
        // � ���������� ����� ������ � ������� ������, ��� ������ �����, ��...
        if (distance < detectionDistance && distance > attackDistance)
        {

            //�������� �������� ����
            anim.SetBool("run", true);
        }
        //�����...
        else
        {
            //��������� �������� ����
            anim.SetBool("run", false);
        }

        if (distance > detectionDistance)
        {
            anim.SetBool("idle", true);
        }
        else
        {
            anim.SetBool("idle", false);
        }
    }

    public virtual void Attack()
    {
        
        
        //���� ���������� ����� ������ � ������� ������, ��� ���������� ��� ����� � ������ ������ ��������(����� ����� �������) ��...
        if (distance < attackDistance )
        {
            
            //���������� �������� �����            
            anim.SetBool("att", true);
        }
        //�����...
        else
        {
            //��������� �������� �����
            anim.SetBool("att", false);
        }
        
    }

}