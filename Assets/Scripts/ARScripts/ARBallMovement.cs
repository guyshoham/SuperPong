﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARBallMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed, originalSpeed;
    private const float DISCOUNT_FACTOR = 0.85f;
    private int lastCollision;
    public bool collided = false;

    void Start()
    {
        lastCollision = 0;
        setBallVelocity();
    }

    void Update()
    {
        this.speed = Mathf.Max(this.originalSpeed, this.speed * DISCOUNT_FACTOR);
        rb.velocity = rb.velocity.normalized * this.speed;
    }

    public float getOriginalSpeed()
    {
        return this.originalSpeed;
    }

    public void setOriginalSpeed(float newSpeed)
    {
        originalSpeed = newSpeed;
    }

    void OnTriggerEnter(Collider collision)
    {
        Vector3 velocity = rb.velocity;

        if (collision.gameObject.tag == "Wall" && !collided)
        {
            collided = true;
            velocity.x *= -1;
            velocity.z += 0.009f;
            rb.velocity = velocity;
        }

        if (collision.gameObject.tag == "Paddle")
        {
            if (collision.gameObject.name == "Player2")
            {
                float paddleX = collision.transform.position.x;
                float ballX = this.transform.position.x;
                float ballPosition = ballX - paddleX; //the position of the ball relative to the paddle center
                lastCollision = 2;

                if (ballPosition < 0)
                {
                    //the ball is left to the paddle
                    if (velocity.x > 0)
                    {
                        velocity.x *= -1;
                    }
                }
                else if (ballPosition > 0)
                {
                    //the ball is right to the paddle
                    if (velocity.x < 0)
                    {
                        velocity.x *= -1;
                    }
                }
            }
            else
            {
                float paddleX = collision.transform.position.x;
                float ballX = this.transform.position.x;
                float ballPosition = ballX - paddleX; //the position of the ball relative to the paddle center
                lastCollision = 1;

                if (ballPosition > 0)
                {
                    //the ball is left to the paddle
                    if (velocity.x < 0)
                    {
                        velocity.x *= -1;
                    }
                }
                else if (ballPosition < 0)
                {
                    //the ball is right to the paddle
                    if (velocity.x > 0)
                    {
                        velocity.x *= -1;
                    }
                }
            }

            velocity.z *= -1;
            rb.velocity = velocity;
            FindObjectOfType<AudioManager>().Play("Ball Hit");
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            collided = false;
        }
    }

    public void setBallVelocity()
    {
        int rnd = Random.Range(0, 2);
        if (rnd == 0)
        {
            rb.velocity = new Vector3(0.5f, 0, 0.5f) * speed;
        }
        else
        {
            rb.velocity = new Vector3(-0.5f, 0, -0.5f) * speed;
        }

        this.originalSpeed = this.speed;
    }
}
