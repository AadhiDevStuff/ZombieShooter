using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    public float pitch;

    [HideInInspector]
    public AudioSource source;


    public bool loop;
}

