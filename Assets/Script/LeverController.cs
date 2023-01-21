using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//
//  Lever Controller .cs
//  Lever Controller Script
//
//  Created by Kyo Matias on 00/00/2022.
//  Copyright © 2022 Kyo Matias. All rights reserved.
//

namespace LeverMain
{



    public class LeverController : MonoBehaviour
    {
        [SerializeField] private Animator _lever = null;
        [SerializeField] private Animator _storageDoor = null;
        public bool IsLeverPulled { get; private set; }
        [SerializeField] private GameObject[] _lights = default;
        

        public Camera playerCamera;


        private void Awake()
        {
            IsLeverPulled = false;
        }

        private void Update()
        {
            if (!IsLeverPulled)
                PullLever();
        }

        private void PullLever()
        {
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit,
                    maxDistance: 3))
            {
                if (hit.transform.CompareTag("ElectricalBox"))
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        Debug.Log("Lever Is Being Pulled");
                        PullSwitch();
                        lightStatus();
                        StorageDoor();
                        IsLeverPulled = true;
                    }
                }
            }
        }

        void PullSwitch()
        {
            _lever.Play("LeverOpen", 0, 0.0f);
            gameObject.SetActive(false);
            _lever.StopPlayback();
        }

        void lightStatus()
        {
            for (int i = 0; i < _lights.Length; i++)
            {
                gameObject.SetActive(true);
            }
        }

        void StorageDoor()
        {

            _storageDoor.Play("StorageRoomDoor", 0, 0.0f);
            gameObject.SetActive(true);
            _storageDoor.StopPlayback();
        }
    }
}


