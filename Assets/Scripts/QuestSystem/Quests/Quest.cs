using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Quest", order = 0)]
public class Quest : ScriptableObject
{
    private bool isComplete;
    private int counter;

    //[Header("Details")]
    public string name;
    public bool IsComplete { get => isComplete; private set => isComplete = value; }
    [SerializeField] public List<Goal> Goals = new List<Goal>();
    [SerializeField] public GameEvent OnQuestComplete;

    private void OnEnable() 
    {
        isComplete = false;
        foreach (var goal in Goals)
        {
            goal.OnGoalComplete.MyEvent += Evaluate;
        }
    }

    private void OnDisable()
    {
        foreach (var goal in Goals)
        {
            goal.OnGoalComplete.MyEvent -= Evaluate;///
        }
    }

    public void Evaluate()
    {
        foreach (var goal in Goals)///
        {
            if (goal.isComplete)
            {
                counter++;
                Debug.Log(Goals.Count);
            }
        }

        if( counter >= Goals.Count)
        {
            isComplete=true;
            OnQuestComplete.MyEvent?.Invoke();
        }
    }

}
