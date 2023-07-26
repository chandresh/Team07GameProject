using System;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class Sound
{
    public string name; //key that will be used for audio clip
    public AudioClip clip; //clip object
    [Range(0f, 1f)]
    public float volume; //volume of audio
    [Range(-3f, 3f)]
    public float pitch; //pitch of audio
    [Range(-1f, 1f)]
    public float pan; //pan of audio, -1 being left, 0 being center, 1 being right
    public bool loop; //should the audio loop or not
    public bool playOnStart; //should the audio play on start or not
    public bool is3D; //should the audio be played in 3d space
    public GameObject locationBind; //should the audio be bound to a gameobjects location
    [HideInInspector]
    public AudioSource source;

}