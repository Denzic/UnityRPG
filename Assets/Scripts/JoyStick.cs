using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JoyStick : MonoBehaviour {
    protected Joystick joystick;
    
    //protected JoyButton joybutton;
    // Use this for initialization
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        virtualInput();
    }
    
    public void virtualInput()
    {
        
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Vector3 movement = new Vector3(joystick.Horizontal * 10f * Time.deltaTime, 0, joystick.Vertical * 10f * Time.deltaTime);
        rigidbody.MovePosition(transform.position + movement);
        if (movement != Vector3.zero)
            rigidbody.rotation = Quaternion.LookRotation(movement);

        if (movement != Vector3.zero)
        {
            gameObject.GetComponent<InputManager>().enabled = false;
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            gameObject.GetComponentInChildren<WeaponAction>().enabled = false;      
        }
        else
        {
            gameObject.GetComponent<InputManager>().enabled = true;
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
            gameObject.GetComponentInChildren<WeaponAction>().enabled = true;
        }
    }

}
