using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject springPrefab;
    public GameObject movingPlatformPrefab;

    private GameObject game;
    private GameObject player;
    private float minX;
    private float maxX;
    private float minY = 0.2f;
    private float maxY = 1f;
    private float range;
    
    private void Start(){
        game = GameObject.Find("Game");
        player = game.GetComponent<GameScript>().player;
        minX = game.GetComponent<GameScript>().minX;
        maxX = game.GetComponent<GameScript>().maxX;
        range = player.GetComponent<PlayerScript>().range;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* Destroyer collides with simple platform */
        if (collision.gameObject.name.StartsWith("Platform"))
        {
            /* 1/7 probability of spawning a spring or a moving platform */
            if (Random.Range(1,8) == 1)
            {
                Destroy(collision.gameObject);
                if (Random.Range(1,3) == 1)
                    Instantiate(springPrefab, new Vector2(Random.Range(minX, maxX), player.transform.position.y + range + Random.Range(minY, maxY)), Quaternion.identity);
                else
                    Instantiate(movingPlatformPrefab, new Vector2(Random.Range(minX, maxX), player.transform.position.y + range + Random.Range(minY, maxY)), Quaternion.identity);
            }
            /* 6/7 probability of keeping the platform (moving it) */
            else
                collision.gameObject.transform.position = new Vector2(Random.Range(minX, maxX), player.transform.position.y + range + Random.Range(minY, maxY));
            
        }
        /* Destroyer collides with spring or moving platform */
        else if (collision.gameObject.name.StartsWith("Spring") || collision.gameObject.name.StartsWith("Moving"))
        {
            /* 1/7 probability of keeping the platform (moving it) */
            if (Random.Range(1,8) == 1)
                collision.gameObject.transform.position = new Vector2(Random.Range(minX, maxX), player.transform.position.y + range + Random.Range(minY, maxY));
            
            /* 6/7 probability of spawning a simple platform */
            else
            {
                Destroy(collision.gameObject);
                Instantiate(platformPrefab, new Vector2(Random.Range(minX, maxX), player.transform.position.y + range + Random.Range(minY, maxY)), Quaternion.identity);
            }   
        }
    }
}
