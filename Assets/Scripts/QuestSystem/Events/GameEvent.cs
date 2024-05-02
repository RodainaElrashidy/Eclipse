using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/GameEvent", order = 1)]
public class GameEvent : ScriptableObject 
{
    private UnityAction myEvent;
    public UnityAction MyEvent { get => myEvent; set => myEvent = value; }
    // public UnityEvent GameAction { get { return myEvent; } set { myEvent = value; } }
}