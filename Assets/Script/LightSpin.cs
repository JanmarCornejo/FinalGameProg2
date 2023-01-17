using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpin : MonoBehaviour
{
    [SerializeField] int XSpin;
    [SerializeField] int YSpin;
    [SerializeField] int ZSpin;


    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(XSpin * Time.deltaTime, YSpin * Time.deltaTime, ZSpin * Time.deltaTime, Space.Self);
    }
}
