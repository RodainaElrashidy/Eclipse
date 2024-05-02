using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.Animations;


public class NPCInteraction : MonoBehaviour
{
    [SerializeField] Flowchart flowchart;
    [SerializeField] Quest quest;
    [SerializeField] private Animator npcAnimator; 
    [SerializeField] private RuntimeAnimatorController die;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            flowchart.ExecuteBlock("AskingForHelp");
        }
    }

    public void EndGoal()
    {
        quest.Goals[1].onAlertGoal.MyEvent?.Invoke();
    }

    public void PlayDead()
    {
        npcAnimator.runtimeAnimatorController = die;
    }
}
