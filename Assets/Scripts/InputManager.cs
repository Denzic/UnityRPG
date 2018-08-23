using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InputManager : MonoBehaviour {
    public Camera cam;
    public NavMeshAgent agent;
    
	// Update is called once per frame
	void Update () {
        InputControl();
	}

    public void InputControl()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = cam.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject TouchedObject = hit.collider.gameObject;
                if (TouchedObject.tag == "InteractableObject")
                {
                    print("interactable object touched");
                    TouchedObject.GetComponent<Interactable>().MoveToInteraction(agent);
                }
                else
                    agent.SetDestination(hit.point);
            }
            //print(Input.GetTouch(0).position);
        }  
    }
}
