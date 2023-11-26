using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    public List<Quest> quests = new List<Quest>();

    private void Awake()
        {
        if (instance == null)
            {
            instance = this;
            }
        else
            {
            Destroy(gameObject);
            }
        }

    public void UpdateQuest(string questID)
        {
        Quest quest = quests.Find(q => q.questID == questID);

        if (quest != null)
            {
            quest.UpdateProgress();
            Debug.Log("Quest updated: " + quest.questID);
            }
        else
            {
            Debug.LogWarning("Quest not found: " + questID);
            }
        }
    }
