using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//  SecondFloorRoom.cs
//  Second Floor Room Trigger Script
//
//  Created by Kyo Matias on 01/21/2023.
//  Copyright © 2022 Kyo Matias. All rights reserved.
//
public class SecondFloorRoom : MonoBehaviour
{
    [SerializeField] private GameObject _spiderTrigger = null;

    private bool _passedRoom;
    // Start is called before the first frame update

    private void Awake()
    {
        _passedRoom = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _spiderTrigger.SetActive(true);
            Debug.Log("trigger active");
        }
    }
}
