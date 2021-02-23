using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorScript : MonoBehaviour
{

    public GameObject platform;
    public int nbPlatforms = 200;
    public float width = 3f;
    public float minY = 0f;
    public float maxY = 1.3f;

    void Start()
    {
       Vector3 spawnPosition = new Vector3();
        for (int i = 0; i < nbPlatforms; i++)
        {
            spawnPosition.x = Random.Range(-width, width);
            spawnPosition.y += Random.Range(minY, maxY);
            Instantiate(platform, spawnPosition, Quaternion.identity);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
