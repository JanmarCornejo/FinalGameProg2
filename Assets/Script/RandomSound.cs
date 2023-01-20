using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    private bool isMakingSound = false;
    [SerializeField] private float timeDelay;
    [SerializeField] private float SoundLength;

    [SerializeField] AudioClip[] randomSounds;

    AudioSource RandomAudioSource;

    private void Start()
    {
        RandomAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isMakingSound == false)
        {
            StartCoroutine(MakeSound());
        }
    }

    IEnumerator MakeSound()
    {
        isMakingSound = true;
        Sounds();
        timeDelay = Random.Range(0.01f, SoundLength);
        yield return new WaitForSeconds(timeDelay);
        isMakingSound = false;
    }

    void Sounds()
    {
        AudioClip clip = randomSounds[UnityEngine.Random.Range(0, randomSounds.Length)];
        RandomAudioSource.PlayOneShot(clip);
    }
}
