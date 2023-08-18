using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    private static readonly string LogPrefix = "[SoundManager]";
    public static AudioManager instance;
    public Sound[] sounds;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds) CreateAudioSource(s, gameObject);
        Debug.Log($"{LogPrefix} created AudioSource object for each sound");
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

    public Sound Play(string name)
    {
        Sound sound = GetSound(name);
        sound.source.Play();
        return sound;
    }

    public Sound PlayDelayed(string name, float delayInSeconds)
    {
        Sound sound = GetSound(name);
        sound.source.PlayDelayed(delayInSeconds);
        return sound;
    }

    public Sound Stop(string name)
    {
        Sound sound = GetSound(name);
        sound.source.Stop();
        Debug.Log($"{LogPrefix} Stopped sound {name} from playing");
        return sound;
    }

    public void StopAllSounds()
    {
        foreach (Sound s in sounds) s.source.Stop();
        Debug.Log($"{LogPrefix} Stopped all sounds from playing");
    }

    public Sound SetSoundLocation(string name, Vector3 location)
    {
        Sound sound = GetSound(name);
        if (!sound.is3D) throw new Exception($"{LogPrefix} There is no need to update a location of a 2D sound");
        sound.source.transform.position = location;
        return sound;
    }

    public Sound UpdateSound(
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
        return sound;
    }

    public Sound BindSoundToGameObjectLocation(string name, GameObject gameObject)
    {
        // assuming the sound is wanting to be set as 3d if its being bound to a dynamic location
        Sound sound = GetSound(name);
        sound.source.spatialBlend = 1.0f;
        sound.is3D = true;
        sound.locationBind = gameObject;
        return sound;
    }

    private Sound GetSound(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        return sound ?? throw new Exception($"{LogPrefix} Unable to find sound with the key '{name}'");
    }

    private void CreateAudioSource(Sound sound, GameObject gameObject)
    {
        sound.source = gameObject.AddComponent<AudioSource>();
        sound.source.clip = sound.clip;
        sound.source.volume = sound.volume;
        sound.source.pitch = sound.pitch;
        sound.source.loop = sound.loop;
        sound.source.panStereo = sound.pan;
        if (sound.is3D) sound.source.spatialBlend = 1.0f;
    }

    /**
     * Usage:
     * Top level audio manager that exists on all scenes and doesn't get destroyed so that sounds can exist over scene changes (music etc)
     * Child prefab on game objects for individual sounds (such as player shooting)
     * 
     * Get audio manager instance
     * Example:
     *  1. Get top level
     *      AudioManager am = FindObjectOfType<AudioManager>();
     *  2. Get Child prefab
     *      AudioManager am = this.gameObject.GetComponentInChildren<AudioManager>(); 
            if (am == null) return;
     * 
     * Playing sound (name is a mandatory param) (returns sound object)
     *  Sound sound = am.Play(name:"Sound");
     * 
     * Updating sound (name is the only mandatory param) (returns sound object)
     *  Sound sound = am.Update(name:"Sound", volume:0.5f, pitch:1.2f, loop:false);
     * 
     * Bind location of 3d sound to location of game object in update method (returns sound object)
     *  Sound sound = am.BindSoundToGameObjectLocation(name:"Sound", gameObject: Player)
     */
}
