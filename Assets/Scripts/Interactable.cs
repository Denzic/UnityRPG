using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {
    public NavMeshAgent Agent;

    public virtual void MoveToInteraction(NavMeshAgent agent)
    {
        this.Agent = agent;
        agent.destination = this.transform.position;

        Interact();
    }

    public virtual void Interact()
    {
        print("Interacting");
    }

}
