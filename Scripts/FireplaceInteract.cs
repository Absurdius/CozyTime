using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplaceInteract : MonoBehaviour, Interactable
{
    public void Interact()
    {
        Animator animator = GetComponent<Animator>();
        if (animator == null) {Debug.Log("Animator not found for fireplace");}
        animator.SetBool("isBurning", true);
    }
}
