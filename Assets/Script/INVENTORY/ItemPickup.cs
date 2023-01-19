using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    private Camera playerCamera;

    void Pickup()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
        Debug.Log("Item Obtained.");
    }


    private void OnMouseDown()
    {
        Pickup();
    }
}
