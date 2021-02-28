using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathScript : MonoBehaviour
{
    public GameObject player;
    private float range;

    private void Start() 
    {
        range = player.GetComponent<PlayerScript>().range;
    }
    
    /* Move DeathLimits with player */
    private void Update() 
    {
        
        if (player.transform.position.y > transform.position.y + range)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y - range, transform.position.z);
        }
        
    }

    /* Player collides with DeathLimits and die */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject == player)
        {
            player.GetComponent<PlayerScript>().Death();
        }
    }
}
