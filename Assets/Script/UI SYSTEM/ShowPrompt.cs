using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowPrompt : MonoBehaviour
{
    public TextMeshPro showPromptText;

    void OnTriggerEnter(Collider EnteringTheTrigger)
    {
        if(EnteringTheTrigger.tag == "Player")
        {
            Debug.Log("Player is by the trigger area.");            
            showPromptText.enabled = true;
        }
    }

    void OnTriggerExit(Collider LeavingTheTrigger)
    {
        if(LeavingTheTrigger.tag == "Player")
        {
            Debug.Log("Player left the trigger area.");
            showPromptText.enabled = false;
        }
    }
}
