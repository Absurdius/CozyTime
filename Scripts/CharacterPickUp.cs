using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterPickUp : MonoBehaviour
{

    private GameObject objectInRange;
    private Boolean isCarrying = false;

    void Update()
    {
        if (Input.GetButtonUp("Fire1") && objectInRange != null) {
            if (isCarrying) {
                objectInRange.transform.parent = null;
            } else {
                objectInRange.transform.parent = gameObject.transform;

            }
            isCarrying = !isCarrying;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Moveable"))
        {
            objectInRange = other.gameObject;
            Debug.Log("Close to object");
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
            objectInRange = null;
        Debug.Log("Leaving object");
    }
}
