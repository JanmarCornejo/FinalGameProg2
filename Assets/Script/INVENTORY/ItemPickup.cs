using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPickup : MonoBehaviour//, IDataPersistence
{

    /*[SerializeField] private string ID;

    [ContextMenu("Generate guid for ID")]

    private void GenerateGuid()
    {
        ID = System.Guid.NewGuid().ToString();
    }
    */
    [Header("Item Type")]
    [SerializeField] private bool isFirstKeyCard = true;
    [SerializeField] private bool isSecondKeyCard = true;
    [SerializeField] private bool isThirdKeyCard = true;

    public static bool AccuiredFirstKeyCard{ get; private set; }
    public static bool AccuiredSecondKeyCard { get; private set; }
    public static bool AccuiredThirdKeyCard { get; private set; }

    public GameObject dialogueTrigger;

    public TextMeshProUGUI showAcquiredPrompt;
    public TextMeshProUGUI showDialogueText;
    public Image showUnderlineAnim;

    public Item item;

    public Camera playerCamera;

    private void Start()
    {
        showAcquiredPrompt.gameObject.SetActive(false);
        dialogueTrigger.gameObject.SetActive(false);
    }

    private void Awake()
    {
        AccuiredFirstKeyCard = false;
        AccuiredSecondKeyCard = false;
        AccuiredThirdKeyCard = false;
    }

    void Update()
    {
        if (isFirstKeyCard)
            InteractFirstKeyCard();

        if (isSecondKeyCard)
            InteractSecondKeyCard();

        if (isThirdKeyCard)
            InteractThirdKeyCard();

    }

    void Pickup()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }

    public void EnableDialogueTrigger() // Enables dialogue (four) trigger box after picking up keycard_2
    {
        dialogueTrigger.gameObject.SetActive(true);
    }

    public void EnableText()
    {
        showAcquiredPrompt.gameObject.SetActive(true);
        showUnderlineAnim.gameObject.SetActive(true);

    }

    public void EnableDialogue()
    {
        showDialogueText.gameObject.SetActive(true);
    }

    private void InteractFirstKeyCard()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, 3))
        {
            if (hit.transform.CompareTag("FirstKeyCard"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    Pickup();
                    EnableText();

                    AccuiredFirstKeyCard = true;

                    Debug.Log("CEO Keycard Obtained.");
                }
            }
        }
    }

    public void InteractSecondKeyCard()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, 3))
        {
            if (hit.transform.CompareTag("SecondKeyCard"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    Pickup();
                    EnableText();
                    EnableDialogueTrigger();
                    FindObjectOfType<SoundManager>().Play("MetalOpen");

                    Debug.Log("All Access Keycard Obtained.");
                    AccuiredSecondKeyCard = true;
                    Debug.Log("Second keycard true");
                }
            }
        }
    }

    private void InteractThirdKeyCard()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, 3))
        {
            if (hit.transform.CompareTag("ThirdKeyCard"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    Pickup();
                    EnableText();
                    EnableDialogue();
                    AccuiredThirdKeyCard = true;

                    Debug.Log("Elevator Keycard Obtained.");
                }
            }
        }
    }
    /// for loading items data sana kaso di ko talaga kaya.

   /* public void LoadData(GameData data)
    {
        data.KeyCardsCollected.TryGetValue(ID, out isFirstKeyCard);
        if (isFirstKeyCard)
        {
            gameObject.SetActive(false);
            data.KeyCardsCollected.TryGetValue(ID, out isSecondKeyCard);
            if (isSecondKeyCard)
            {
                gameObject.SetActive(false);
            }
            data.KeyCardsCollected.TryGetValue(ID, out isThirdKeyCard);
            if (isThirdKeyCard)
            {
                gameObject.SetActive(false);
            }
        }
    }*/



    /// for saving items data sana kaso di ko talaga kaya.



    /*public void SaveData(ref GameData data)
    {
        if (data.KeyCardsCollected.ContainsKey(ID))
        {
            data.KeyCardsCollected.Remove(ID);
        }
        data.KeyCardsCollected.Add(ID, isFirstKeyCard);
        if (data.KeyCardsCollected.ContainsKey(ID))
        {
            data.KeyCardsCollected.Remove(ID);
        }
        data.KeyCardsCollected.Add(ID, isSecondKeyCard);
        if (data.KeyCardsCollected.ContainsKey(ID))
        {
            data.KeyCardsCollected.Remove(ID);
        }
        data.KeyCardsCollected.Add(ID, isThirdKeyCard);
    }
    /*
    private void OnMouseDown()
    {
        Pickup();
    }
    */
}
