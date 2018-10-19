using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScripts : MonoBehaviour {
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector3(0, -10, 10);
        Destroy(gameObject, 5); //测试时为了不占内存，5秒后删除物体，可以不用

	}
}
