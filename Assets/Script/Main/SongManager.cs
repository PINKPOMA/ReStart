using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongManager : MonoBehaviour
{
    public AudioSource music;
    public AudioClip clip;

    public string songName;
    public bool isGameFin;

    int previewTime;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        music = GetComponent<AudioSource>();

        previewTime = 30;
    }
    
    public void PlayAudioForPlayScene()
    {
        music.timeSamples = 0;
        music.PlayDelayed(3.0f);
    }
    
    public void FinishSong()
    {
        isGameFin = music.isPlaying;

        if (isGameFin.Equals(false))
            SceneManager.LoadScene("Result");
    }

    public void SelectSong(string songName)
    {
        this.songName = songName;
        music.Stop();
    }

    public void PlayAudioPreview(string songName)
    {
        clip = Resources.Load(songName+"/"+songName) as AudioClip;
        music.clip = clip;
        music.timeSamples = 0;
        music.timeSamples += music.clip.frequency * previewTime;

        music.Play();

    }
}