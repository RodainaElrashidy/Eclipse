using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
   // [SerializeField] private UnityEvent _onInteract;
    [SerializeField] private Canvas promptCanvas;
    [SerializeField] private GameEvent OnAlertGoal;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material outlineMaterial;
    /// 

    private Material[] ogMaterials;
    private bool check;
    private void Start()
    {
        ogMaterials = meshRenderer.materials;
        if(gameObject.name == "Chest")
        {
            OnAlertGoal = null;
        }
    }

    public void Interact() 
    {
       if(gameObject.name != "Chest" && OnAlertGoal.MyEvent != null)
        {
            OnAlertGoal.MyEvent.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            promptCanvas.gameObject.SetActive(true);
            if(!check)
                AddOutline();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        promptCanvas.gameObject.SetActive(false);
        RemoveOutline();
    }

    private void AddOutline()
    {
        check = true;

        Material[] materials = new Material[meshRenderer.materials.Length + 1];

        for(int i = 0; i < meshRenderer.materials.Length; i++)
        {
            materials[i] = meshRenderer.materials[i];
        }

        materials[materials.Length - 1] = outlineMaterial;

        meshRenderer.materials = materials;
    }

    private void RemoveOutline() 
    {
        if (meshRenderer.materials.Length > ogMaterials.Length)//
        {
            Material[] newMaterials = new Material[meshRenderer.materials.Length - 1];

            for (int i = 0; i < newMaterials.Length; i++)
            {
                newMaterials[i] = meshRenderer.materials[i];
            }

            meshRenderer.materials = newMaterials;
        }

        check = false;
    }
}
