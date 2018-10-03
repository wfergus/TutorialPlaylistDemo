﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private float speed = 5;
   

    private float horizontalInput;
	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        horizontalInput = Input.GetAxis("Horizontal");

	}
    private void FixedUpdate()
    {
        rb2d.AddForce(Vector2.right * horizontalInput * speed);
        
    }
}
