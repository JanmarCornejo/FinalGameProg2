using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//  .cs
//  Script
//
//  Created by Kyo Matias on 00/00/2022.
//  Copyright © 2022 Kyo Matias. All rights reserved.
//
public class CEOSPIDER : MonoBehaviour
{
    [SerializeField] private GameObject _spiderTrigger = null;

    private bool _didPlayerPass;

    private void Awake()
    {
        _didPlayerPass = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _spiderTrigger.SetActive(true);
            Debug.Log("CEO Room trigger Active");
        }
    }
}
