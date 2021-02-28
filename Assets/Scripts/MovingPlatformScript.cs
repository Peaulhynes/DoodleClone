using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : PlatformScript
{
    public float speed;
    private bool movingRight = true;
    private GameObject game;
    private float minX;
    private float maxX;

    private void Start() {
        game = GameObject.Find("Game");
        minX = game.GetComponent<GameScript>().minX;
        maxX = game.GetComponent<GameScript>().maxX;
    }

    void Update()
    {
        /* Moving right */
        if (movingRight){
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            if (transform.position.x >= maxX)
                movingRight = false;
        }
        /* Moving left */
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y); 
            if (transform.position.x <= minX)
                movingRight = true;
        }
    }
}
