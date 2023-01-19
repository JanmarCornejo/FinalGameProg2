using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPickup : MonoBehaviour
{
    [Header("Item Type")]
    [SerializeField] private bool isFirstKeyCard = true;
    [SerializeField] private bool isSecondKeyCard = true;
    [SerializeField] private bool isThirdKeyCard = true;

    public TextMeshProUGUI showAcquiredPrompt;

    public Item item;

    public Camera playerCamera;

    private float timeToAppear = 2f;
    private float timeWhenDisappear;

    void Update()
    {
        if (isFirstKeyCard)
            InteractFirstKeyCard();

        if (isSecondKeyCard)
            InteractSecondKeyCard();

        if (isThirdKeyCard)
            InteractThirdKeyCard();

        if (showAcquiredPrompt.enabled && (Time.time >= timeWhenDisappear))
        {
            showAcquiredPrompt.enabled = false;
        }
    }

    void Pickup()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }

    public void EnableText()
    {
        showAcquiredPrompt.enabled = true;
        timeWhenDisappear = Time.time + timeToAppear;
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

                    Debug.Log("Level 2 KeyCard Obtained.");
                }
            }
        }
    }

    private void InteractSecondKeyCard()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, 3))
        {
            if (hit.transform.CompareTag("SecondKeyCard"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    Pickup();
                    EnableText();

                    Debug.Log("CEO KeyCard Obtained.");
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

                    Debug.Log("Executive Card Obtained.");
                }
            }
        }
    }

    /*
    private void OnMouseDown()
    {
        Pickup();
    }
    */
}
