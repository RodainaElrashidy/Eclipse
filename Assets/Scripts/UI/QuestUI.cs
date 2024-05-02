using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questName;
    [SerializeField] TextMeshProUGUI goalOneDescription;
    [SerializeField] TextMeshProUGUI goalTwoDescription;

    [SerializeField] Quest quest;//

    // Start is called before the first frame update
    void Start()
    {
        QuestPanelSetUp();//
    }
    
    private void Awake()
    {
        quest.OnQuestComplete.MyEvent += CompletedQuestUpdate;
        quest.Goals[0].OnGoalComplete.MyEvent += CompletedGoalUpdate;
        if (quest.Goals.Count > 1)//
        {
            quest.Goals[1].OnGoalComplete.MyEvent += CompletedGoalUpdate;
            goalTwoDescription.gameObject.SetActive(true);
        }
    }
    private void OnDisable()
    {
        quest.OnQuestComplete.MyEvent -= CompletedQuestUpdate;
        quest.Goals[0].OnGoalComplete.MyEvent -= CompletedGoalUpdate;

        if (quest.Goals.Count > 1)
        {
            quest.Goals[1].OnGoalComplete.MyEvent -= CompletedGoalUpdate;
        }
    }

    private void QuestPanelSetUp()
    {
        questName.text = quest.name;
        goalOneDescription.text = quest.Goals[0].description;

        if (quest.Goals.Count > 1)//
        {
            goalTwoDescription.text = quest.Goals[1].description;
        }
    }

    private void CompletedQuestUpdate()
    {
        questName.color = new Color(questName.color.r,
                                    questName.color.g,
                                    questName.color.b,
                                                0.3f);
    }

    private void CompletedGoalUpdate()
    {
        if (quest.Goals[0].isComplete)
        {
            goalOneDescription.color = new Color(goalOneDescription.color.r,
                                                goalOneDescription.color.g,
                                                goalOneDescription.color.b,
                                                0.3f);
        }

        if (quest.Goals.Count > 1 && quest.Goals[1].isComplete)
        {
            goalTwoDescription.color = new Color(goalTwoDescription.color.r,
                                                goalTwoDescription.color.g,
                                                goalTwoDescription.color.b,
                                                0.3f);
        }   
    }
}
