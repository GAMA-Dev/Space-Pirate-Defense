using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsManager : MonoBehaviour {

    public static SoundEffectsManager instance;
    public AudioSource source;
    public AudioClip[] sounds;

    private void Awake()
    {       
        if (instance != null)
        {
            Debug.LogError("More than one Sound Effects Manager in scene!");
            return;
        }
        instance = this; 
    }

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
