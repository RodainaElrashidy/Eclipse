using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ExitScenarios : MonoBehaviour
{

    [SerializeField] Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
        //flow
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            flowchart.ExecuteBlock("AskingForHelp");
        }
    }
}
