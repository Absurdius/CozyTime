using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmchirInteractable : MonoBehaviour, Interactable
{
    public GameObject gameObjectToReveal;

    public void Interact()
    {
        GameObject.Find("MainCharacter").SetActive(false);
        gameObjectToReveal.SetActive(true);
    }
}
