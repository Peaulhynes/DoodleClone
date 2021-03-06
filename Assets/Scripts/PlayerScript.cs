﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerScript : MonoBehaviour
{
    public float movement = 0f;
    public float speed = 10f;
    public float range = 7f;
    public Rigidbody2D body;
    private float topScore = 0.0f;
    public Text scoreText;

    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.gravityScale = 0f;
        body.velocity = Vector3.zero;
    }

    /* Sprite direction and score update */
    void Update()
    {
        this.GetComponent<SpriteRenderer>().flipX = (movement < 0);
        UpdateScore();
    }

    /* Collision with clone */
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name.StartsWith("Clone")){
            Death();
        }
    }

    /* Player movement */
    public void GetInput()
    {
        movement = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(movement * speed, body.velocity.y);
    }

    /* Score increments with height */
    public void UpdateScore()
    {
        if (body.velocity.y > 0 && transform.position.y > topScore){
            topScore = transform.position.y;
        }
        scoreText.text = "Score : " + Mathf.Round(topScore).ToString();
    }

    /* Game Over */
    public void Death()
    {
        SceneManager.LoadScene("GameOver");
    }
}
