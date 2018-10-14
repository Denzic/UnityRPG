using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CallAudio : MonoBehaviour {
    public AudioSource audioSource;
    //public List<AudioClip> audioSourceList;
    public AudioSource backgroudMusic;
    public AudioSource attackSource;
    

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
            
        }
        else
        {
            audioSource.Stop();
        }
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().hasPath)
        {
            audioSource.Stop();
        }
    }

    //void AttackAudio()
    //{
    //    if (GetComponent<WeaponAction>().animator.isActiveAndEnabled)
    //    {
    //        if (!attackSource.isPlaying)
    //        {
    //            attackSource.Play();
    //        }
    //        audioSource.volume = 1f;
    //        //Debug.Log("attsource");
    //    }
    //    else
    //    {
    //        attackSource.Stop();
    //        Debug.Log("aa");
    //    }
        
    //}
}
