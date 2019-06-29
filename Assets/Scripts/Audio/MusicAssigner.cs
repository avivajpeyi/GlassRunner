using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicAssigner : MonoBehaviour
{

    public bool isMuted = false;
    public AudioClip gameAudio;
    AudioSource musicPlayer;

    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        musicPlayer.clip = gameAudio;
        musicPlayer.Play();

    }


}
