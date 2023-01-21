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
public class LeverController : MonoBehaviour
{
    [SerializeField] private Animator _lever = null;
    private bool _isLeverPulled = false;
    [SerializeField] private Light[] _lights = default;

    public Camera playerCamera;

    private void Start()
    {
        togglelight(false);
    }

    private void Update()
    {
        PullLever();
    }

    private void PullLever()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, maxDistance: 3))
        {
            if (hit.transform.CompareTag("ElectricalBox"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    Debug.Log("Lever Is Being Pulled");
                    PullSwitch();
                    lightStatus();
                }
            }
        }
    }

    void PullSwitch()
    {
        _lever.Play("LeverOpen", 0, 0.0f);
            gameObject.SetActive(false);
    }

    void lightStatus()
    {
        togglelight(true);
    }

    void togglelight(bool enabled)
    {
        foreach (var light in _lights)
        {
            light.gameObject.SetActive(enabled);
        }
    }
    
}


