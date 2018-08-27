using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InputManager : MonoBehaviour {

    public Camera cam;
    public NavMeshAgent agent;
    public Vector3 movement;
    private float movementSqrMagnitude;
    public float WalkSpeed = 1.5f;

    // Update is called once per frame
    void Update () {
        TouchInput();
    }

    public void TouchInput()
    {
        if (!agent.hasPath)
            gameObject.GetComponent<JoyStick>().enabled = true;
        //check touch input
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Ray ray = cam.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject TouchedObject = hit.collider.gameObject;
                if (TouchedObject.tag == "InteractableObject" || TouchedObject.tag == "Enemy")
                {
                    //print("interactable object touched");
                    TouchedObject.GetComponent<Interactable>().MoveToInteraction(agent);
                }
                else
                {
                    agent.stoppingDistance = 0f;
                    if (agent.hasPath)
                        gameObject.GetComponent<JoyStick>().enabled = false;
                    
                    agent.SetDestination(hit.point);
                }
            }
            //print(Input.GetTouch(0).position);
        }  
    }

}
