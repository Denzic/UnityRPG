using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {
    public NavMeshAgent Agent;
    private bool hasInteracted;

    public virtual void MoveToInteraction(NavMeshAgent agent)
    {
        hasInteracted = false;
        this.Agent = agent;
        agent.stoppingDistance = 3f;
        agent.destination = transform.position;
        if (agent.hasPath)
            GameObject.FindGameObjectWithTag("Player").GetComponent<JoyStick>().enabled = false;
    }
    void Update()
    {
        if (!hasInteracted && Agent != null && !Agent.pathPending)
        {
            if (Agent.remainingDistance <= Agent.stoppingDistance)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }
    public virtual void Interact()
    {
        //will run for the first frame.
            //print("Interacting");
    }

}
