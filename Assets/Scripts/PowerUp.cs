﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PowerUp : MonoBehaviour
{
	private float nextPowerUpTime = 0.0f;
	private bool isPowerUpOnStage = false;
	public GameObject pickupEffect;
	public BallMovement ball;
	public Transform player1, player2;
	
	void Start()
	{
		nextPowerUpTime = Random.Range(5f,30f); 
	}

	void Update()
	{
		if(isPowerUpOnStage == false && nextPowerUpTime < Time.time)
		{
			this.transform.position = new Vector3(Random.Range(-5.0f, 5.75f),transform.position.y, Random.Range(-5.0f, 5.25f));
			isPowerUpOnStage = true;
		}
		// PowerUp Rotate animation
		transform.Rotate(0, 50 * Time.deltaTime, 0); 
	}
	
    void OnTriggerEnter(Collider collider)
	{
		if(collider.tag == "Ball")
		{
			Pickup(collider);
		}
	}
	
	void Pickup(Collider collider)
	{
		// Create and destroy PowerUp effect
		GameObject effect = Instantiate(pickupEffect, transform.position, transform.rotation) as GameObject;
		Destroy(effect, 0.5f);
	
		// Get rid of the PowerUp for a few seconds 
		transform.position = new Vector3(5000f, transform.position.y, 5000f);
		isPowerUpOnStage = false;
		nextPowerUpTime = Random.Range(30f,100f) + Time.time;

		Vector3 position = collider.transform.position;
		if(this.gameObject.name == "Elephant")
		{
			if(collider.transform.localScale.x == 0.5f)
			{
				collider.transform.localScale = new Vector3(1f,1f,1f);
				collider.transform.position = new Vector3(position.x,1f,position.z);
			}
			else
			{
				collider.transform.localScale = new Vector3(2f,2f,2f);
				collider.transform.position = new Vector3(position.x,1.5f,position.z);
			}
		}
		if(this.gameObject.name == "Mouse")
		{
			
			if(collider.transform.localScale.x == 2f)
			{
				collider.transform.localScale = new Vector3(1f,1f,1f);
				collider.transform.position = new Vector3(position.x,1f,position.z);
			}
			else
			{
				collider.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
				collider.transform.position = new Vector3(position.x,0.75f,position.z);
			}
		}
		if(this.gameObject.name == "Rabbit")
		{
			if(ball.speed == 10)
			{
				ball.speed = 15;
			}
			if(ball.speed == 5)
			{
				ball.speed = 10;
			}
		}
		if(this.gameObject.name == "Turtle")
		{
			if(ball.speed == 15)
			{
				ball.speed = 10;
			}
			if(ball.speed == 10)
			{
				ball.speed = 5;
			}
		}
		if(this.gameObject.name == "Giraffe")
		{
			if(ball.lastCollision == 1)
			{
				player1.localScale = new Vector3(5f, 1f, 1f);
			}
			if(ball.lastCollision == 2)
			{
				player2.localScale = new Vector3(5f, 1f, 1f);
			}
		}
	}
}
