using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerScript : MonoBehaviour
{
    public float movement = 0f;
    public float speed = 10f;
    public Rigidbody2D body;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * speed;
    }

    void FixedUpdate() 
    {
        Vector2 velocity = body.velocity;
        velocity.x = movement;
        body.velocity = velocity;
    }
}
