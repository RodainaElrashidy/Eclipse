using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWay : MonoBehaviour
{
    [SerializeField] Quest quest;//
    [SerializeField] Collider boxCollider;
    private void OnEnable()
    {
        quest.OnQuestComplete.MyEvent += AllowPassage;
    }

    private void OnDisable()
    {
        quest.OnQuestComplete.MyEvent -= AllowPassage;
    }

    private void AllowPassage()
    {
        boxCollider.isTrigger = true;
    }
}
