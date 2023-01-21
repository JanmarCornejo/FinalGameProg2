using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LeverMain;
using Unity.VisualScripting;

//
//  SpiderDoor.cs
//  Spider Door Script
//
//  Created by Kyo Matias on 01/20/2023.
//  Copyright © 2022 Kyo Matias. All rights reserved.
//
public class SpiderDoor : MonoBehaviour
{
    [SerializeField] private Animator _spiderDoor = null;
    private bool _isSpiderDoorOpen = false;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var leverController = FindObjectOfType<LeverController>();
            if (leverController != null && leverController.IsLeverPulled)
            {
                _spiderDoor.Play("SpiderDoor",0, 0.0f);
            }
        }
    }
}
