using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float bounce = 10f;

    /* Player collides with platform : bounce */
    void OnCollisionEnter2D(Collision2D collision) 
    {
        /* Bounce only with top collision */
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D body = collision.collider.GetComponent<Rigidbody2D>();
            if (body != null)
            {    
                body.velocity = new Vector2(body.velocity.x, bounce);
            }
        }
    }
}
