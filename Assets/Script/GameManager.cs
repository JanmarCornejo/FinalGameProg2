using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<SoundManager>().Play("BGM");
    }

    void Update()
    {
        
    }
}
