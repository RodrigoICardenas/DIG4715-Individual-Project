using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects2 : MonoBehaviour
{
    public AudioSource levelMusic;
    public AudioSource winSong;

    public bool levelSong = true;
    public bool WinSong = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelMusic()
    {
        levelSong = true;
        WinSong = false;
        levelMusic.Play();

    }

    public void WinSound()
    {
        if (levelMusic.isPlaying)
            levelSong = false;
            levelMusic.Stop();
        if (!winSong.isPlaying && WinSong == false)
        {
            winSong.Play();
            WinSong = true;
        }
    }
}