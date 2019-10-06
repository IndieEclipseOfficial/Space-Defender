using UnityEngine;

[System.Serializable]
public class Sounds {

    public string soundName;
    public AudioClip clip;

    public float volume;
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}
