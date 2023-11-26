using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{
    public string questID;
    public string questTitle;
    public int requiredInteractions;
    private int currentInteractions;

    public void UpdateProgress()
        {
        currentInteractions++;

        if (currentInteractions >= requiredInteractions)
            {
            CompleteQuest();
            }
        }

    private void CompleteQuest()
        {
        Debug.Log("Quest completed: " + questTitle);
        }
    }
