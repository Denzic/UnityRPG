using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CallAudio : MonoBehaviour {
    public AudioSource audioSource;
    //public List<AudioClip> audioSourceList;
    public AudioSource backgroudMusic;

    // Use this for initialization

    // Update is called once per frame
    void Update () {
        audioSource = gameObject.GetComponent<AudioSource>();
        MovementAudio();
      //  audioSource.Play();

    }

    void MovementAudio()
    {

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().hasPath)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            audioSource.volume = 1f;
            
            print("gg");
        }
        else
        {
            audioSource.Stop();
            print("pp");
        }
        //if (!GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().hasPath)
        //{
        //    audioSource.Stop();
        //}
    }
}
