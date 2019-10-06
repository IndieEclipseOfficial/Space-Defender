using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

    public Sounds[] sounds;
    public static AudioManager instance;

    private void Awake() {
        foreach (var sound in sounds) {
            sound.source = gameObject.AddComponent<AudioSource>();

            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
        }

        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    public void Play(string nameOfClip) {
        Sounds s = Array.Find(sounds, sound => sound.soundName == nameOfClip);
        s.source.Play();
    }
}
