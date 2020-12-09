using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake ()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void ChangeVolume (float amt)
    {

        foreach (Sound s in sounds)
        {
            if (amt < 0)
                s.source.volume = 0;
            else if (amt > 1)
                s.source.volume = 1;
            else
                s.source.volume = amt;
        }
    }
}
