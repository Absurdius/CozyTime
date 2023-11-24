using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMyFire : MonoBehaviour {
    
    private Animator animator;
    private GameObject mainChar; 

    void Start()
    {
        this.animator = GetComponent<Animator>();
        if (animator == null) { Debug.Log("Animator not found for fireplace"); }
    }

    void Update()
    {
        if (Input.GetButtonUp("Fire1") && mainChar != null && mainChar.transform.childCount == 1)
        {
            Debug.Log("LightFire");
            lightFire();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MainCharacter"))
        {
            Debug.Log("Main char is near fireplace");
            mainChar = other.gameObject;
            Debug.Log("With " + mainChar.transform.childCount + " child");
        }        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MainCharacter"))
        {
            Debug.Log("Main char left fireplace");
            mainChar = null;
        }
    }

    private void lightFire()
    {
        animator.SetBool("isBurning", true);
    }
}
