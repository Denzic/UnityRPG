using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour {

    public Camera mainCam;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (mainCam != null)

            transform.LookAt(transform.position + mainCam.transform.rotation * Vector3.back,
            mainCam.transform.rotation * Vector3.up);
    }


}
