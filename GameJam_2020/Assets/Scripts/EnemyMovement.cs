using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMovement : MonoBehaviour
{
    public GameObject[] targets;
    public NavMeshAgent agent;
    private int currentTarget = 1;

    void Start() { 
            agent.SetDestination(targets[getTarget()].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == targets[currentTarget].transform.position)
        {
            agent.SetDestination(targets[getTarget()].transform.position);
        }
    }

    private int getTarget()
    {
        if (currentTarget == 1) { 
            currentTarget = 0;  
            return 0; 
        };
        currentTarget = 1;
        return 1;
    }
}
