using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStar : MonoBehaviour
{


    //  public AudioSource collectSound;

    void OnTriggerEnter(Collider other)
    {
        //      collectSound.Play();
        Destroy(gameObject);
        ScoringSystem.theScore += 50;
        Pilot.speed += 5f;
        
    }
}
