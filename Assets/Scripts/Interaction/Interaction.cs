using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    public UnityEvent interactionEvent;

    private ThirdPersonController controller;
    private Interactable currentInteractable;

    private void Awake()
    {
        controller = this.GetComponent<ThirdPersonController>();
    }
    private void Update()
    {
        if (currentInteractable != null && controller.PlayerActions.Interact.triggered)
            DoInteract();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Interactable")
        {
            if(other.gameObject.TryGetComponent<Interactable>(out Interactable _interactable))
                currentInteractable = _interactable;
        }
    }

    private void DoInteract()
    {
        currentInteractable.Interact();
        Debug.Log("Hi");
    }

}
