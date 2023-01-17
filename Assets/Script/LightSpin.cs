using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpin : MonoBehaviour
{
    [SerializeField] int Speed;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0f, 0f, Speed * Time.deltaTime, Space.Self);
    }
}
