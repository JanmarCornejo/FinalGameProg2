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
public class DoorKeyCard : MonoBehaviour
{
  [SerializeField] private Animator DoorAnimation = null;
  public bool KeyCheck { get; set; }

  [SerializeField] private Camera PlayerCamera;

  private void Awake()
  {
    SetKey();
  }

  private void SetKey()
  {
    KeyCheck = false;
    Debug.Log("$KeyCheck =" + KeyCheck);
  }

  private void Update()
  {
    if (!KeyCheck)
    {
      UseKey();
    }

    var keycard = GetComponent<ItemPickup>();
    {
      KeyCheck = true;
    }
  }

  #region KeyCardChecking
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
          
        }
      }
    }
  }

  

  #endregion
}


