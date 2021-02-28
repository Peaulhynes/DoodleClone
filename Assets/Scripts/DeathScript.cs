using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathScript : MonoBehaviour
{
    public GameObject player;
    private void Update() 
    {
        
        if (player.transform.position.y > transform.position.y + 10)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y - 10, transform.position.z);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject == player)
        {
            player.GetComponent<PlayerScript>().Death();
        }
    }
}
