using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSFX : MonoBehaviour
{
    public GameObject explosionSoundTrigger;

    void OnTriggerEnter(Collider EnteringTheTrigger)
    {
        if (EnteringTheTrigger.tag == "Player")
        {
            FindObjectOfType<SoundManager>().Play("Explosion");
            Debug.Log("Explosion SFX.");
            explosionSoundTrigger.gameObject.SetActive(false);


        }
    }
}
