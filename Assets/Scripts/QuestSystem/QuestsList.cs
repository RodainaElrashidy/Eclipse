using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Quest List", order = 0)]
public class QuestsList : ScriptableObject
{
    [SerializeField] public List<Quest> myQuests = new List<Quest>();
}
