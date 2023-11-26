using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    public Text questInfoText;
    public QuestManager questManager;

    void Start()
    {
        questInfoText.text = "Quest Status:\n";
    }

    public void QuestTextUpdate(Quest quest)
    {
        questInfoText.text = quest.questTitle;
    }
}
