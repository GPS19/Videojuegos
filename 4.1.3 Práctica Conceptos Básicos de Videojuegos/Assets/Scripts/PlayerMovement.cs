using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 * Pablo Yamamoto, Santiago Kohn, Gianluca Beltran
 *
 * PlayerMovement script is in charge of managing the players movement,
 * in the case of this game the movement can only be up and down and it
 * can be controlled by w, a or up and down keys.
 */


public class PlayerMovement : MonoBehaviour
{
    private Vector3 motion;

    [SerializeField] private float speed;
    

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        motion.y = Input.GetAxisRaw("Vertical"); // Fetching user input
        transform.position = transform.position + motion * speed * Time.deltaTime; // Updating GameObjects position. Time.deltaTime ensures that the GameObjects movement is framerate independent.
    }
    
}
