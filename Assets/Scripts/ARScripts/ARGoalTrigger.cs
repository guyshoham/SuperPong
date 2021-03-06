﻿using UnityEngine;
using System;

public class ARGoalTrigger : MonoBehaviour
{
    public ARGameManager gameManager;
    public GameObject ball;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            if (this.name == "Gate2")
            {
                //the scorer is player2
                gameManager.Goal(2);
            }
            else
            {
                //the scorer is player1
                gameManager.Goal(1);
            }
            ball.SetActive(false);
            FindObjectOfType<AudioManager>().Play("Goal");
        }
    }
}
