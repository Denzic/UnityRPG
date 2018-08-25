using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC {

    public Transform enemy;
	// Use this for initializations
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        //collider.tag;	
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("collided");
        if(other.tag == "LongSword")
        {
            Destroy(gameObject);
        }
    }
}
