using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPosition : MonoBehaviour {

    public Camera cam;

    private void Start()
    {
        //cam = Camera.current;

    }

    private void Update()
    {
        cam.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}
