using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIMovement : MonoBehaviour {    
   
    public Transform goal;
    NavMeshAgent agent;
    public float[] enemyAttackID; 
    public float enemyID = 000f;
    [SerializeField] private float detectRadius;
    [SerializeField] private float followRadius;

    private bool isFollowing;

    private void Awake()
    {
        goal = GameObject.Find("Player").transform;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void FixedUpdate() {
        agent.destination = goal.position;
        /*if (isFollowing)
        {
            if(Vector3.Distance(transform.position, goal.position) > followRadius)
            {
                isFollowing = false;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, goal.position) < detectRadius)
            {
                isFollowing = true;
            }
        }

        if (isFollowing)
        {
            if(agent.isStopped)
            {
                agent.isStopped = false; 
            }

            Vector3 pos = goal.gameObject.GetComponent<Rigidbody>().position;
            float x = pos.x % 10;
            float z = pos.z % 10;
            pos = new Vector3(x, 0, z);
            agent.destination = pos;
        }
        else
        {
            if (!agent.isStopped)
            {
                agent.isStopped = true;
            }
        }*/
    }
}