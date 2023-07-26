using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.panStereo = s.pan;
            if (s.is3D) s.source.spatialBlend = 1.0f;
        }
    }

    private void Start()
    {
        foreach (Sound s in sounds)
            if (s.playOnStart)
                Play(s.name);
    }

    private void Update()
    {
        foreach (Sound s in sounds)
            if (s.is3D)
                if (s.locationBind != null)
                    s.source.transform.position = s.locationBind.transform.position;

    }

    public void Play(string name)
    {
        GetSound(name).source.Play();
    }

    public void Stop(string name)
    {
        GetSound(name).source.Stop();
    }

    public void StopAllSounds()
    {
        foreach (Sound s in sounds) s.source.Stop();
    }

    public void SetSoundLocation(string name, Vector3 location)
    {
        Sound sound = GetSound(name);
        if (!sound.is3D) throw new Exception($"There is no need to update a location of a 2D sound");
        sound.source.transform.position = location;
    }

    public void UpdateSound(
        string name,
        float? volume = null,
        float? pitch = null,
        float? pan = null,
        bool? loop = null,
        bool? is3D = null
        )
    {
        Sound sound = GetSound(name);
        if (volume != null) sound.source.volume = Mathf.Clamp((float)volume, 0f, 1f);
        if (pitch != null) sound.source.pitch = Mathf.Clamp((float)pitch, -3f, 3f);
        if (pan != null) sound.source.panStereo = Mathf.Clamp((float)pan, -1f, 1f);
        if (loop != null) { sound.source.loop = sound.loop = (bool)loop; };
        if (is3D != null) { sound.source.spatialBlend = (bool)is3D ? 1.0f : 0.0f; sound.is3D = (bool)is3D; };
    }

    public void BindSoundToGameObjectLocation(string name, GameObject gameObject)
    {
        // assuming the sound is wanting to be set as 3d if its being bound to a dynamic location
        Sound sound = GetSound(name);
        sound.source.spatialBlend = 1.0f;
        sound.is3D = true;
        sound.locationBind = gameObject;
    }

    private Sound GetSound(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        return sound ?? throw new Exception($"[SoundManager] Unable to find sound with the key '{name}'");
    }

    /**
     * Playing sound (name is a mandatory param)
     * FindObjectOfType<AudioManager>().Play(name:"Sound");
     * 
     * Updating sound (name is the only mandatory param)
     * FindObjectOfType<AudioManager>().Update(name:"Sound", volume:0.5f, pitch:1.2f, loop:false);
     * 
     * Bind location of 3d sound to location of game object in update method
     * BindSoundToGameObjectLocation(name:"Sound", gameObject: Player)
     */
}
