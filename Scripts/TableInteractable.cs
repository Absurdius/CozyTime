using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableInteractable : MonoBehaviour, Interactable
{
    public GameObject chocolateOnTable;

    public void Interact()
    {
        chocolateOnTable.SetActive(true);
    }
}
