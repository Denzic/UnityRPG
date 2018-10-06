using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour {

    public Camera cam;
    public NavMeshAgent agent;
    public Vector3 movement;
    private float movementSqrMagnitude;
    public float WalkSpeed = 1.5f;

    // Update is called once per frame
    void Update () {

        TouchInput();
        clickInput();
        //KeyInput();
        //CharacterRotation();
        //CharacterPostion();

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended
            && !EventSystem.current.IsPointerOverGameObject())
            TouchInput();

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            MouseInput();
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
                if (TouchedObject.tag == "InteractableObject" && TouchedObject.tag != "Button")
                {
                    TouchedObject.GetComponent<Interactable>().MoveToInteraction(agent, Input.GetTouch(0).position);
                }
                else
                {
                    agent.stoppingDistance = 0f;
                    if (agent.hasPath)
                        gameObject.GetComponent<JoyStick>().enabled = false;
                    
                    agent.SetDestination(hit.point);
                }
            }
        }  
    }


    public void clickInput()
    {

    }
    // Only for testing purpose
    public void MouseInput()
    {
        if (!agent.hasPath)
            gameObject.GetComponent<JoyStick>().enabled = true;
        //check touch input

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject TouchedObject = hit.collider.gameObject;

                if (TouchedObject.tag == "InteractableObject" || TouchedObject.tag == "Enemy")
                {
                    //print("interactable object touched");
                    TouchedObject.GetComponent<Interactable>().MoveToInteraction(agent);
                if (TouchedObject.tag == "InteractableObject" )
                {
                    TouchedObject.GetComponent<Interactable>().MoveToInteraction(agent, Input.mousePosition);
                }
                else
                {
                    agent.stoppingDistance = 0f;
                    agent.SetDestination(hit.point);

                }

            }
            //print(Input.GetTouch(0).position);
        }
    }
    //public void KeyInput()
    //{
    //    float x = Input.GetAxis("Horizontal");
    //    float z = Input.GetAxis("Vertical");
    //    movement = new Vector3(x, 0, z);
    //    movement = Vector3.ClampMagnitude(movement, 1.0f);
    //    movementSqrMagnitude = Vector3.SqrMagnitude(movement);
    //}
                    if (agent.hasPath)
                        gameObject.GetComponent<JoyStick>().enabled = false;

                    agent.SetDestination(hit.point);
                }
            }
        }
    }

}
