using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

    private float radius = 0.5f;
    public float Radius { get { return radius; } set { radius = value; } }
    public Vector3 Direction { get; set; }
    public float Range { get; set; }
    Vector3 spwanPostion;

    void Start()
    {
        spwanPostion = transform.position;
        Range = 20f;
        transform.localScale = transform.localScale * 0.8f;
        GetComponent<Rigidbody>().AddForce(Direction * 50f);
    }

    void Update()
    {
        if(Vector3.Distance(spwanPostion, transform.position) >= Range)
            Extiguish();
    }

    private void OnTriggerEnter(Collider other)
    { 
        Extiguish();
        if (other.tag == "Enemy")
        {

        }
    }

    void Extiguish()
    {
        Destroy(gameObject);
    }


}
