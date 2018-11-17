using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    #region variables
    // public
    public SoundItem[] sounds;
    // private
    #endregion

    #region UnityMethods
    private void Awake()
    {
        foreach (SoundItem sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;

            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.loop = sound.loop;
        }
    }
	#endregion
	
	#region MyMethods
    public void Play(string name)
    {
        SoundItem s = Array.Find(sounds, sound => sound.name == name);
        s.audioSource.Play();
    }
	#endregion
}

