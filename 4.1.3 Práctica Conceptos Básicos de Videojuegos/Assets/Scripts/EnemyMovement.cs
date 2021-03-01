using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

/*
 * Pablo Yamamoto, Santiago Kohn, Gianluca Beltran
 *
 * EnemeyMovement script is in charge of moving the enemies (UFO's) from side to side.
 * The enemies have a trigger collider that subtract score from the player when he hits them.
 */

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private float cameraBoundsX;
    private float width;
    [SerializeField] int startDirection = 1; // Starting moving direction of enemies. 1 = right, -1 = left.
    private Score finishLine;

    // Start is called before the first frame update
    void Start()
    {
        finishLine = FindObjectOfType<Score>(); // Fetching Score object. 
        cameraBoundsX = Camera.main.aspect * Camera.main.orthographicSize * 2; // Formula to get the width of the camera.
        width = GetComponent<SpriteRenderer>().size.x * transform.localScale.x / 2; // Formula to get the width of the scaled Sprite of the enemies.
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > cameraBoundsX/2 - width || transform.position.x < cameraBoundsX/2 * - 1 + width) // If condition to determine if the enemy should move right or left. 
        {
            startDirection *= -1; // Multiplying direction by -1 in order to get corresponding direction
            transform.position = new Vector2(-startDirection * cameraBoundsX/2f + startDirection * width, transform.position.y); // This was added to avoid a bug where the enemy would get stuck in one of the edges of the screen
        }
        transform.position = new Vector2(transform.position.x + speed * startDirection * Time.deltaTime, transform.position.y); // Updating the position of the enemies, allowing them to move. 
    }

    private void OnTriggerEnter2D(Collider2D other) // Managing trigger collisions of the player with the enemies.
    {
        finishLine.SubScore(); // Public method from Score script that subtracts one from the game score. 
        Debug.Log(finishLine.getScore());
    }
}
