using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private GameObject carryable;
    private Interactable interactable;
    private Boolean isCarrying = false;

    private Vector3 overHeadPosition = new Vector3(0f, 1.25f, 0f);
    private Vector3 putDownPosition = new Vector3(-1.0f, -0.9f, 0f);

    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            if (isCarrying && this.interactable != null) {
                InteractWithAndDestroy();
            } else if ( isCarrying && this.interactable == null) {
                PutDown();
            } else if (!isCarrying){
                PickUp();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Moveable"))
        {
            carryable = other.gameObject;
            Debug.Log("Close to object");
        } else if (other.gameObject.CompareTag("Interactable"))
        {
            FindInteractable(other);
            Debug.Log("Close to interactable");
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Moveable") && !isCarrying) 
        {
            carryable = null;
            Debug.Log("leaving object"); 
        }
        else if (other.gameObject.CompareTag("Interactable"))
        {
            interactable = null;
        }
    }

    private void PutDown()
    {
        carryable.transform.localPosition = putDownPosition;   
        carryable.transform.parent = null;
        isCarrying = false;
    }

    private void PickUp()
    {
        if(carryable != null) { 
            carryable.transform.parent = gameObject.transform;
            carryable.transform.localPosition = overHeadPosition;
            isCarrying = true;
        }
    }

    private void InteractWith()
    {
        this.interactable.Interact();
    }    
    
    private void InteractWithAndDestroy()
    {
        this.interactable.Interact();
        if (this.carryable != null) { 
            GameObject.Destroy(this.carryable); 
            this.carryable = null;
            isCarrying = false;
        } 

    }

    private void FindInteractable(Collider2D other)
    {
        foreach (MonoBehaviour b in other.GetComponents<MonoBehaviour>())
        {
            if (b is Interactable)
            {
                this.interactable = b as Interactable;
                Debug.Log("Found Interactable");
                break;
            }
        }
    }
}
