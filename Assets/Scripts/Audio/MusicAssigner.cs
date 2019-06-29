using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAssigner : MonoBehaviour
{

    public AudioClip gameAudio;
    AudioSource musicPlayer;


    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        musicPlayer.clip = gameAudio;
        musicPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
