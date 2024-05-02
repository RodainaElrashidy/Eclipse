using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class QuestManager : MonoBehaviour
{
    [SerializeField] public List<Quest> quests = new List<Quest>();
    [SerializeField] public Flowchart[] flowcharts = new Flowchart[4];
    
    void Start()
    {
        foreach (Quest quest in quests)
        {
            quest.Goals.ForEach(go => { go.currentAmount = 0; });
        }
    }

    private void OnEnable()
    {
        quests[0].OnQuestComplete.MyEvent += QuestOneDone;
        quests[1].OnQuestComplete.MyEvent += QuestTwoDone;
        quests[2].OnQuestComplete.MyEvent += QuestThreeDone;
        quests[3].OnQuestComplete.MyEvent += QuestFourDone;
    }

    private void OnDisable()
    {
        quests[0].OnQuestComplete.MyEvent -= QuestOneDone;
        quests[1].OnQuestComplete.MyEvent -= QuestTwoDone;
        quests[2].OnQuestComplete.MyEvent -= QuestThreeDone;
        quests[3].OnQuestComplete.MyEvent -= QuestFourDone;
    }


    private void QuestOneDone()
    {
        flowcharts[0].ExecuteBlock("QuestOneDone");
    }
    
    private void QuestTwoDone()
    {
        flowcharts[1].ExecuteBlock("QuestTwoDone");
    }
    
    private void QuestThreeDone()
    {
        flowcharts[2].ExecuteBlock("QuestThreeDone");
    }
    
    private void QuestFourDone()
    {
        flowcharts[3].ExecuteBlock("QuestFourDone");
    }
}
