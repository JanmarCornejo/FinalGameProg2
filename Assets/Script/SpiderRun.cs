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
public class SpiderRun : MonoBehaviour
{
    [SerializeField] private Animator _spiderRun = null;
    private bool _didSpiderPass;

    private void Awake()
    {
        _didSpiderPass = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _spiderRun.Play("SpiderRun",0,0.0f);
            
        }

        _didSpiderPass = true;
    }
}
