using System.Collections;
using System.Collections.Generic;
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
    public float speed = 1.0f;

    private Transform transform;
    private Vector2 movement = Vector2.zero; 
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        this.animator = GetComponent<Animator>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
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
        transform.Translate(speed * Time.deltaTime * movement);
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
