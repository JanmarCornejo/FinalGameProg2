using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{

    private bool isFlickering = false;
    [SerializeField] private float timeDelay;

    void Update()
    {
        if(isFlickering == false)
        {
            StartCoroutine(FlickeringLight());
        }
    }

    IEnumerator FlickeringLight()
    {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.01f, 0.5f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(0.01f, 0.5f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }

}
