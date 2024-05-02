using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
[CreateAssetMenu(menuName = "Goal", order = 0)]
public class Goal : ScriptableObject
{
    [Header("Details")]
    public bool isComplete;
    public string description;
    public int requiredAmount;
    public int currentAmount;

    [SerializeField] public GameEvent OnGoalComplete;
    [SerializeField] public GameEvent onAlertGoal;

    private void OnEnable()
    {
        isComplete = false;
        onAlertGoal.MyEvent += IncreaseAmount; 
    }
    
    
    private void OnDisable()
    {
        onAlertGoal.MyEvent -= IncreaseAmount;
    }

    public string GetDescription()
    {
        return description;
    }

    private void IncreaseAmount()
    {
        //Debug.Log("increased");
        currentAmount++;
        //Debug.Log(currentAmount);
        Evaluate();
    }

    private void Evaluate()
    {
        if(currentAmount >= requiredAmount)
        {
            isComplete = true;
            OnGoalComplete.MyEvent?.Invoke();
        }
    }
}