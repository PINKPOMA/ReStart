using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongItemBoard : MonoBehaviour
{
    public Text textName;
    public Text textLevel;
    public Text textArtitst;
    public Image sprite;

    public delegate void SongItemDisplayDelegate(SongItem item);
    public event SongItemDisplayDelegate onClick;

    public SongItem item;

    public SongManager songManager;
    static string songCheck = "";
    static int clickCnt = 0;
    void Start()
    {
        if (item != null) Prime(item);

        songManager = GameObject.Find("SelectSong").GetComponent<SongManager>();
    }

    public void Prime(SongItem item)
    {
        this.item = item;
        if (textName != null)
            textName.text = item.songName;
        if (textLevel != null)
            textLevel.text = item.songLevel;
        if (textArtitst != null)
            textArtitst.text = item.songArtist;
        if (sprite != null)
            sprite.sprite = item.sprite;
    }

    public void Click()
    {
        if (onClick != null)
            onClick.Invoke(item);
        else
        {
            if (songCheck.Equals(item.songName))
                clickCnt++;
            else
            {
                clickCnt = 0;
                songCheck = item.songName;
                clickCnt++;
            }
            songManager.PlayAudioPreview(item.songName);
            
            if (clickCnt.Equals(2))
            {
                songManager.SelectSong(item.songName);
                clickCnt = 0;
                SceneManager.LoadSceneAsync("Play");
            }
        }
    }
}
