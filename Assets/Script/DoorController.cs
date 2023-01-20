using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//  DoorController.cs
//  Janitor Door Controller Script
//
//  Created by Kyo Matias on 01/20/2023.
//  Copyright © 2022 Kyo Matias. All rights reserved.
//
public class DoorController : MonoBehaviour
{
   [SerializeField] private Animator _janitor = null;
   [SerializeField] private bool _opentrigger = false;

   private void OnTriggerEnter(Collider other)
   {
       if (other.CompareTag("Player"))
       {
           if (_opentrigger)
           {
               _janitor.Play("JaniDoorOpen", 0 , 0.0f);
               gameObject.SetActive(false);
           }
       }
   }


   // Start is called before the first frame update
    void Start()
    {
        
    }
    
}
