﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.AI;

public class AIMovement : MonoBehaviour {       
    public Transform goal;
    NavMeshAgent agent;
    void Start () {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update() {
        agent.destination = goal.position;     
    }
}