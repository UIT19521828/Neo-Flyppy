using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music nhac;
    public List<AudioClip> clips;
    public AudioSource source;
    private int current = 0;
    void Awake()
    {
        nhac = this;
        DontDestroyOnLoad(this);
    }
    public void ChangeMusic(int which)
    {
        if (which != current)
        {
            current = which;
            source.clip = clips[current];
            source.Play();
        }
    }
}
