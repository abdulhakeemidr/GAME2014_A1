using UnityEngine.Audio;
using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Sound[] Sounds;
    //void Awake()
    //{
    //    foreach(Sound s in Sounds)
    //    {
    //        gameObject.AddComponent<AudioSource>();
    //        s.source.clip = s.clip;
    //        s.source.volume = s.volume;
    //        s.source.pitch = s.pitch;
    //    }
    //}

    //private void Start()
    //{
    //    Play("Background Music");
    //}

    //public void Play(string name)
    //{
    //    Sound s = Array.Find(Sounds, Sound => Sound.name == name);
    //    s.source.Play();
    //}
}
