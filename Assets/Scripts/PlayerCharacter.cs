using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    private float accelerationForce = 5;

    [SerializeField]
    private float jumpForce = 5;

    [SerializeField]
    private float maxSpeed = 5;

    [SerializeField]
    private Collider2D groundDetectTrigger;

    [SerializeField]
    private ContactFilter2D groundContactFilter;

    private float horizontalInput;
    private bool isOnGround;
    private Collider2D[] groundHitDetectionResults = new Collider2D[16];
    

    void Update ()
    {
        UpdateIsOnGround();
        UpdateHorizontalInput();
        HandleJumpInput();
    }

    private void UpdateHorizontalInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }
    private void UpdateIsOnGround()
    {
       isOnGround = groundDetectTrigger.OverlapCollider(groundContactFilter, groundHitDetectionResults) > 0;
       // Debug.Log("IsOnGround?: " + isOnGround);
    }
    private void HandleJumpInput()
    {
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb2d.AddForce(Vector2.right * horizontalInput * accelerationForce);
        Vector2 clampedVelocity = rb2d.velocity;
        clampedVelocity.x = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = clampedVelocity;
    }
}
