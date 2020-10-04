using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAsteroid : MonoBehaviour
{
    public Pilot pilot;

    void Update()
    {
        gameObject.transform.Rotate(-1f, 0f, 0f, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        ScoringSystem.theScore -= 10;
        pilot.TakeDamage(1);
    }

}
