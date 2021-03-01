using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Pablo Yamamoto, Santiago Kohn, Gianluca Beltran
 *
 * Score script is in charge of managing the score of the game.
 * The player loses a point everytime he hits an enemy and gains
 * a point everytime he reaches the finish line.
 */
public class Score : MonoBehaviour
{
    private int score = 0;

    private void OnTriggerEnter2D(Collider2D other) // Called when player enters finish line.
    {
        score++;
        FindObjectOfType<PlayerMovement>().transform.position = new Vector2(0, -4); // The position of the player is reset to the starting position
        Debug.Log(score);
    }

    public void SubScore() // Public method to subtract score 
    {
        score--;
    }

    public int getScore() // Public getter for the score variable
    {
        return score;
    }
}
