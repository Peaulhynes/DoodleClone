﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{

    public float bounce = 10f;
    void OnCollisionEnter2D(Collision2D collision) 
    {
        // Top collision
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D body = collision.collider.GetComponent<Rigidbody2D>();
            if (body != null)
            {    
                Vector2 velocity = body.velocity;
                velocity.y = bounce;
                body.velocity = velocity;
            }
        }
    }
}
