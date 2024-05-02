using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class UIManager : MonoBehaviour
{
    [SerializeField] Canvas questCanvas;

    public void ShowQuestMenu(InputAction.CallbackContext context)
    {
        questCanvas.gameObject.SetActive(true);
    }

    public void HideQuestMenu()
    {
        questCanvas.gameObject.SetActive(false);
    }
}
