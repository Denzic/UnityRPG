using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : Interactable {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact()
    {
        GameObject.FindGameObjectWithTag("MagicManager").GetComponent<JoyButton>().healthPotion = 300;
    }
}
