using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//
//  .cs
//  Script
//
//  Created by Kyo Matias on 00/00/2022.
//  Copyright © 2022 Kyo Matias. All rights reserved.
//
public class ElevatorDoor : MonoBehaviour
{
    [SerializeField] private Animator _doorAnim = null;
    [SerializeField] private bool _IsKeycardInInventory;

    
    private bool _Elevator;
    public Camera PlayerCamera;
    
    private void Awake()
    {
        _Elevator = false;
        _IsKeycardInInventory = false;
    }

    private void Update()
    {
        if (!_IsKeycardInInventory)
        {
            CheckKeyCard();
        }
        
        if (!_Elevator)
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
                if (hit.transform.CompareTag("KeyCardDoor3"))
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
        if (ItemPickup.AccuiredThirdKeyCard)
        {
            _IsKeycardInInventory = true;
            Debug.Log("You Have First Keycard");
            return;
        }
        
        _IsKeycardInInventory = false;
    }

    void UnlockDoor()
    {
        if (_IsKeycardInInventory)
        {
            _doorAnim.Play("ElevatorDoorOpen",0,0.0f);
            Debug.Log("CEO Door Open");
            _Elevator = true;
        }
        Debug.Log("CEO Door Is Locked");
    }
}
