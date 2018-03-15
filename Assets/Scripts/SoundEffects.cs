using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour {

    public AudioSource source;
    public AudioClip[] sounds;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void playSoundEffect(string soundName)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name.Equals(soundName))
            {
                source.PlayOneShot(sounds[i]);
            }
        }
    }
}
