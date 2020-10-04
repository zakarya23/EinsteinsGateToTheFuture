using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockets : MonoBehaviour
{
    public GameObject chemRocket;
    public GameObject emagRocket;

    void Start()
    {
        chemRocket.SetActive(false);
        emagRocket.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoringSystem.propStage == 1)
        {
            chemRocket.SetActive(true);
            emagRocket.SetActive(false);
        }
        else if (ScoringSystem.propStage == 2)
        {
            emagRocket.SetActive(true);
            chemRocket.SetActive(false);
        }
    }
}
