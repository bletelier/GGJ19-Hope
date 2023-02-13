using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerFX : MonoBehaviour
{
    static AudioSource audioSrc;    
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(AudioClip clips)
    {
        audioSrc.clip = clips;
        audioSrc.Play();
    }
}
