using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//  CEO.cs
//  Script
//
//  Created by Kyo Matias on 00/00/2022.
//  Copyright © 2022 Kyo Matias. All rights reserved.
//
public class CEODOORSCRIPT : MonoBehaviour
{
    [SerializeField] private Animator _doorAnim = null;
    [SerializeField] private bool _IsKeycardInInventory;

    private bool _CEODoorStatus;

    public Camera PlayerCamera;

    private void Awake()
    {
        _IsKeycardInInventory = false;
        _CEODoorStatus = false;
    }

    private void Update()
    {
        if (!_IsKeycardInInventory)
        {
            CheckKeyCard();
        }

        if (!_CEODoorStatus)
        {
            UseKey();
        }
    }

    void UseKey()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out RaycastHit hit,
                    maxDistance: 3))
            {
                if (hit.transform.CompareTag("KeyCardDoor1"))
                {
                    Debug.Log("Clicking the CEO Door");
                    if (!_IsKeycardInInventory)
                    {
                        CheckKeyCard();
                    }
                    else if (_IsKeycardInInventory)
                    {
                        UnlockDoor();
                    }
                }
            }
        }
    }
    private void CheckKeyCard()
    {
        if (ItemPickup.AccuiredFirstKeyCard)
        {
            _IsKeycardInInventory = true;
            Debug.Log("You Have First Keycard");
            return;
        }
        
        Debug.Log("You Have a KeyCard");
        _IsKeycardInInventory = false;
    }

    void UnlockDoor()
    {
        if (_IsKeycardInInventory)
        {
            _doorAnim.Play("CEODoorOpening",0,0.0f);
            Debug.Log("CEO Door Open");
            _CEODoorStatus = true;
        }
        Debug.Log("CEO Door Is Locked");
    }
}
