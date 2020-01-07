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

        if (isFollowing)
        {
            if(Vector3.Distance(transform.position, goal.position) > followRadius)
            {
                isFollowing = false;
            }
        }
        else
        {
            Physics.Raycast(new Ray(transform.position, goal.position), 30);
        }

        if (isFollowing)
        {
            if(agent.isStopped)
            {
                agent.isStopped = false; 
            }
            agent.destination = goal.position;
        }
        else
        {
            if (!agent.isStopped)
            {
                agent.isStopped = true;
            }
        }
    }
}