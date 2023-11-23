using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public enum Direction {
    UP = 0,
    DOWN = 1,
    // LEFT AND RIGHT MUST BE GREATER THAN 1 BECAUSE OF THE ANIMATOR
    LEFT = 2,
    RIGHT = 3,
}

public class CharacterController2D : MonoBehaviour
{
    public float acceleration = 1.0f;
    public float MAX_SPEED = 1.0f;

    private Transform transform;
    private Vector2 movement = Vector2.zero; 
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody;

    void Start()
    {
        transform = GetComponent<Transform>();
        this.animator = GetComponent<Animator>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
     
        Move(movement);
        SetAnimation();
    }

    private void Move(Vector2 movement)
    {
        if(movement.magnitude > 0f && rigidbody.velocity.magnitude < MAX_SPEED) {
            this.rigidbody.AddForce(movement * rigidbody.mass * acceleration);
        } else { 
            this.rigidbody.AddForce(-rigidbody.velocity * acceleration);
        }

    }

    private void SetAnimation()
    {
        if(movement.x > 0.5f) {
            // RIGHT
            spriteRenderer.flipX = false;
            animator.SetInteger("direction", (int) Direction.RIGHT);
        } else if (movement.x < -0.5) {
            // LEFT
            spriteRenderer.flipX = true;
            animator.SetInteger("direction", (int)Direction.LEFT);
        } else if (movement.y > 0.5) {
            // UP 
            animator.SetInteger("direction", (int)Direction.UP);
        } else if (movement.y < -0.5){
            // DOWN
            animator.SetInteger("direction", (int)Direction.DOWN);
        }
    }
}
