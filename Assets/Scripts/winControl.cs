using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winControl : MonoBehaviour
{
    public AudioSource camara;
    public AudioSource audiosrc;
    public AudioClip win;

    // Start is called before the first frame update
    void Start()
    {
        camara = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        audiosrc = GameObject.Find("Audio Background").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            play(win);
        }
        
    }
    public void play(AudioClip clips)
    {
        audiosrc.Stop();
        camara.clip = clips;
        camara.loop = false;
        camara.Play();
    }


}
