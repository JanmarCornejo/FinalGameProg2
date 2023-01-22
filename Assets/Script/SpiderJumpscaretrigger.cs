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
public class SpiderJumpscaretrigger : MonoBehaviour
{
    [SerializeField] private Animator _spiderRun = null;
    private bool _DidSpiderEntrance;
    [SerializeField] private float timeRemaining = 10;

    private void Awake()
    {
        _DidSpiderEntrance = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _DidSpiderEntrance == true)
        {
            FindObjectOfType<SoundManager>().Play("SpiderFinal");
            _spiderRun.Play("SPiderFinalChase", 0, 0.0f);

        }

        _DidSpiderEntrance = true;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Game Quitting");
            timeRemaining = 0;
            Application.Quit();
        }
    }
}
