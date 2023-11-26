using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    public Text questInfoText;
    public QuestManager questManager;

    // Update is called once per frame
    void Update()
    {
        string questInfo = "Quest Status:\n";

        foreach (Quest quest in questManager.quests)
            {
            questInfo += $"{quest.questTitle}: {quest.currentInteractions}/{quest.requiredInteractions}\n";
            }

        questInfoText.text = questInfo;
        }
    }
