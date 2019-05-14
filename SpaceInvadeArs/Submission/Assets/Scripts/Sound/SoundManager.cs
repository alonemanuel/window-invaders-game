using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager Instance = null;

    public AudioClip neighborBuzz1;
    public AudioClip neighborBuzz2;
    public AudioClip neighborDies;
    public AudioClip ballFire;
    public AudioClip playerHit;
    

    private AudioSource soundEffectAudio;

    // Use this for initialization
    void Start () {

        if (Instance == null)
        {
            Instance = this;
        } else if (Instance!=null)
        {
            Destroy(gameObject);
        }

        AudioSource theSource = GetComponent<AudioSource>();
        soundEffectAudio = theSource;
		
	}
	

    public void PlayOneShot(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);
    }
}
