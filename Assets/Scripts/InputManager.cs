using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InputManager : MonoBehaviour {
    public Camera cam;
    public NavMeshAgent agent;
    //public Vector3 movement;
    //private float movementSqrMagnitude;
    //public float WalkSpeed = 1.5f;

    // Update is called once per frame
    void Update () {
        TouchInput();
        //KeyInput();
        //CharacterRotation();
        //CharacterPostion();

    }

    public void TouchInput()
    {
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

    //public void CharacterRotation()
    //{
    //    Quaternion rotation = Quaternion.LookRotation(movement);
    //    if (movement != Vector3.zero)
    //        transform.rotation = rotation;
    //}

    //public void CharacterPostion()
    //{
    //    transform.Translate(movement * WalkSpeed * Time.deltaTime, Space.World);
    //}
}
