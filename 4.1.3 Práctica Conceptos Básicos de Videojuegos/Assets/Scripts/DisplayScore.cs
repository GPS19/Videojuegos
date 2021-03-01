using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
 * Pablo Yamamoto, Santiago Kohn, Gianluca Beltran
 *
 * DisplayScore script is in charge of displaying the current score of
 * the player. The score gains a point every time the player reaches the finish
 * line and loses one point every time the player hits an enemy (UFO).
 */

public class DisplayScore : MonoBehaviour
{
    // Fetch variables
    Text scoreText;
    [SerializeField] private Score score;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.getScore().ToString(); // Get score from Score script and turn it into a string in order to display it
    }
}
