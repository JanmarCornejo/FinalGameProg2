using UnityEngine.Audio;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;

    public static SoundManager instance;
   
    void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clips;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
           
        }
    }

    /*void Start() for playing theme song.
    {
        Play("Theme");
    }


    //FindObjectOfType<SoundManager>().Play("FallingVent"); for playing sound that you want. */



    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); 
        if (s == null)
            return;
        s.source.Play();
    }
}
