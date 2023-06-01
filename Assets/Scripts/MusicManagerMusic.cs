using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerMusic : MonoBehaviour
{
    private static MusicManagerMusic instance;

    public static MusicManagerMusic Instance
    {
        get { return instance; }
    }

    public AudioClip[] musics;
    public AudioSource auso;
    
    private string musicName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        auso = GetComponent<AudioSource>();
        auso.clip = musics[0];
        musicName = auso.clip.name;
    }
    public void SetMusicScene(int v3)
    {
        string nextMusic = musics[v3].name;

        if (musicName != nextMusic)
        {
            auso.clip = musics[v3];
            auso.Play();
        }
        musicName = nextMusic;
    }
}
