using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    float time = 0;

    // Use this for initialization
    void Start () {
        Time.timeScale = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        print(time);
        print("111111");
	}


}
