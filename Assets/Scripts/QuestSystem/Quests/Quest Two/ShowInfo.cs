using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ShowInfo : MonoBehaviour
{
    [SerializeField] Quest quest;
    [SerializeField] Flowchart flowchart;

    private void OnEnable()
    {
        quest.Goals[0].onAlertGoal.MyEvent += ShowDiary;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowDiary()
    {
        switch (quest.Goals[0].currentAmount)
        {
            case 1: flowchart.ExecuteBlock("EntryOne");
                break;
            case 2:
                flowchart.ExecuteBlock("EntryTwo");
                break;
            case 3:
                flowchart.ExecuteBlock("EntryThree");
                break;
        }
    }
}
