using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public Vector3 centre;
    public Vector3 size;
    public int maxCollectibles = 100;
    public int maxAsteroids = 100;

    public GameObject collectible;
    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;
    public GameObject asteroid4;
    public GameObject asteroid5;

    // Start is called before the first frame update
    void Start()
    { 
        SpawnCollectibles();
        SpawnAsteroids();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCollectibles()
    {
        for (int i = 0; i < maxCollectibles; i++)
        {
            Vector3 pos = centre + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            Instantiate(collectible, pos, Quaternion.identity);
        }
    }

    public void SpawnAsteroids()
    {
        for (int i = 0; i < maxAsteroids; i++)
        {
            Vector3 pos = centre + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            Instantiate(asteroid1, pos, Quaternion.identity);
            Instantiate(asteroid2, pos, Quaternion.identity);
            Instantiate(asteroid3, pos, Quaternion.identity);
            Instantiate(asteroid4, pos, Quaternion.identity);
            Instantiate(asteroid5, pos, Quaternion.identity);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(centre, size);
    }

}
