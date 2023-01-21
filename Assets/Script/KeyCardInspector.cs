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
public class KeyCardInspector : MonoBehaviour
{
    [SerializeField] private bool KeyCard1;
    [SerializeField] private bool KeyCard2;
    [SerializeField] private bool KeyCard3;

    private void Update()
    {
        KeyUpdate();
    }

    void KeyUpdate()
    {
       var Key1=  FindObjectOfType<DoorKeyCard>();
       KeyCard1 = Key1.KeyCheck;
    }
}
