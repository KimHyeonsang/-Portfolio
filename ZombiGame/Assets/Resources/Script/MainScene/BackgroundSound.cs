using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : MonoBehaviour
{
    public AudioClip idleClip;
    public AudioSource AudioSound;
    void Start()
    {
        AudioSound = gameObject.GetComponent<AudioSource>();
        AudioSound.clip = idleClip;
        AudioSound.loop = true;
        AudioSound.playOnAwake = true;

        AudioSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
