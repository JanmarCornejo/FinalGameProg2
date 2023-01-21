using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSFX : MonoBehaviour
{
    public GameObject explosionSoundTrigger;
    public ScreenShake Shake;

    void OnTriggerEnter(Collider EnteringTheTrigger)
    {
        if (EnteringTheTrigger.tag == "Player")
        {
            FindObjectOfType<SoundManager>().Play("Explosion");
            //Shake.BeginShake();
            Debug.Log("Explosion SFX.");
            explosionSoundTrigger.gameObject.SetActive(false);


        }
    }
}
