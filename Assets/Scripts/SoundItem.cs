using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class SoundItem  {

    #region variables
    // public
    public string name;
    public AudioClip clip;
    public bool loop;

    [Range(0f, 1f)]
    public float volume;
    [Range(-3f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource audioSource;
	// private
	#endregion

	#region MyMethods
	#endregion
}
