using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowDialogueText : MonoBehaviour
{
    public TextMeshProUGUI showDialogueText;

    private void Start()
    {
        showDialogueText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider EnteringTheTrigger)
    {
        if (EnteringTheTrigger.tag == "Player")
        {
            Debug.Log("Player enabled the dialogue.");
            showDialogueText.gameObject.SetActive(true);
        }
    }
}
