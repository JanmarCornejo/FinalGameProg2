using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//  KeyCardDoorSecond.cs
//  Key Card Door Second Script
//
//  Created by Kyo Matias on 01/21/2023.
//  Copyright © 2022 Kyo Matias. All rights reserved.
//
public class KeyCardDoorSecond : MonoBehaviour
{
    [SerializeField] private Animator _2fd = null;
    private bool _secondFloorStatus { get; set; }
    [SerializeField] private bool _IsKeycardInInventory;

    public Camera PlayerCamera;


    private void Start()
    {
        _IsKeycardInInventory = false;
    }

    private void Awake()
    {
        _secondFloorStatus = false;
    }

    private void Update()
    {
        if (!_IsKeycardInInventory)
        {

          CheckKeycard();

        }
        
        if (!_secondFloorStatus)
        {
            UseKey();
        }
        
    }


    void UseKey()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out RaycastHit hit,
                    maxDistance: 2))
            {
                if (hit.transform.CompareTag("KeyCardDoor2"))
                {
                    Debug.Log("You are clicking the door");
                    UnlockDoor();
                }
            }
        }
    }
    void CheckKeycard()
    {
        var itemPickup = FindObjectOfType<ItemPickup>();

        if (itemPickup.AccuiredSecondKeyCard)
        {
            _IsKeycardInInventory = true;
            Debug.Log("you have second keycard");
            return;
        }
        
        Debug.Log("You do not have a keycard");
        _IsKeycardInInventory = false;

    }

    void UnlockDoor()
    {
        if (_IsKeycardInInventory)
        {
            _2fd.Play("2fd", 0, 0.0f);
            Debug.Log("2nd floor door is open");
            _secondFloorStatus = true;
        
        }
        Debug.Log("2nd floor door is locked");
    }
}


