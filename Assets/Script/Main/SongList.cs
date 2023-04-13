using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SongList : MonoBehaviour
{
    public List<SongItem> items = new List<SongItem>();
    public SongBoard songBoardPrefab;

    public SongItem songItem;
    public List<NewSongItem> newItems = new List<NewSongItem>();
    public GameObject template;

    int dirCnt;

    void Start()
    {
        AddItem();
        template.AddComponent<SongItem>();

        for(int i=0; i < dirCnt; i++)
        {
            GameObject obj = Instantiate(template);
            SongItem sItem = obj.GetComponent<SongItem>();

            sItem.songName = newItems[i].songName;
            sItem.songArtist = newItems[i].songArtist;
            sItem.songLevel = newItems[i].songLevel;
            sItem.sprite = newItems[i].sprite;

            items.Add(obj.GetComponent<SongItem>());
        }


        SongBoard song = Instantiate(songBoardPrefab);
        song.Prime(items);
    }

    void AddItem()
    {
        string data = "";
        string basePath = Application.dataPath + "/Resources/";
        DirectoryInfo directoryInfo = new DirectoryInfo(basePath);
        foreach(DirectoryInfo di in directoryInfo.GetDirectories())
        {
            dirCnt++;
            using (StreamReader streamReader = new StreamReader(basePath + di.Name + "/" + di.Name + "_data.txt"))
            {
                while((data = streamReader.ReadLine()) != null)
                {
                    string[] splitedData = new string[2];
                    splitedData = data.Split('=');

                    if (splitedData[0] == "Title")
                        songItem.songName = splitedData[1];
                    else if (splitedData[0] == "Artist")
                        songItem.songArtist = splitedData[1];
                    else if (splitedData[0] == "Difficult")
                        songItem.songLevel = splitedData[1];
                    else if (splitedData[0] == "ImageFileName")
                        songItem.sprite = Resources.Load<Sprite>(di.Name + "/" + di.Name + "_Img");
                }
            }

            newItems.Add(new NewSongItem(songItem.songName, songItem.songLevel, songItem.songArtist, songItem.sprite));
        }

    }
}
