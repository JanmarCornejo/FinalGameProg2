using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class OpenInventory : MonoBehaviour
{
    public UnityEvent listItems;

    [SerializeField] private InventoryWindow myInventoryWindow;
    [SerializeField] private Crosshair crosshair;

    public static bool isOpened;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isOpened)
            {
                InventoryExit();
                Debug.Log("Closed Inventory.");

            }
            else
            {
                InventoryOpen();
                listItems.Invoke();
                Debug.Log("Opened Inventory.");
            }
        }
    }

    public void InventoryOpen()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        crosshair.gameObject.SetActive(false);
        myInventoryWindow.gameObject.SetActive(true);
        isOpened = true;
    }

    public void InventoryExit()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        crosshair.gameObject.SetActive(true);
        myInventoryWindow.gameObject.SetActive(false);
        isOpened = false;
    }
}
