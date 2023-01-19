using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    public Camera playerCamera;

    void Update()
    {
        InteractItem();
    }

    void Pickup()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
        Debug.Log("Item Obtained.");
    }

    private void InteractItem()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, 3))
        {
            if (hit.transform.CompareTag("Item"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    Pickup();
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
