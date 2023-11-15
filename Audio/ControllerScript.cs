using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5.0f;
    private new Transform transform;
    private Vector2 movement = Vector2.zero;
    void Start()
    {
     transform = GetComponent<Transform>();   
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        transform.Translate(movement * speed * Time.deltaTime);
    }
}
