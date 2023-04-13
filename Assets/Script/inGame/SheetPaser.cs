using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SheetPaser : MonoBehaviour
{
    TextAsset textAsset;
    StringReader strReader;

    Sheet sheet;
    SongManager songManager;

    string sheetText = "";
    string songName;
    string[] textSplit;

    void Awake()
    {
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();
        songManager = GameObject.Find("SelectSong").GetComponent<SongManager>();
     
        songName = songManager.songName;
        textAsset = Resources.Load(songName + "/" + songName + "_data") as TextAsset;
        strReader = new StringReader(textAsset.text);

        ParseSheet();
    }
    public void ParseSheet()
    {
        int laneNumber;
        float noteTime;

        sheetText = strReader.ReadLine();

        while(sheetText != null)
        {   
            textSplit = sheetText.Split('=');

            if (textSplit[0] == "AudioFileName")  sheet.AudioFileName = textSplit[1];
            else if (textSplit[0] == "ImageFileName")  sheet.ImageFileName = textSplit[1];
            else if (textSplit[0] == "Title")          sheet.Title = textSplit[1];
            else if (textSplit[0] == "Artist")         sheet.Artist = textSplit[1];
            else if (textSplit[0] == "Source")         sheet.Source = textSplit[1];
            else if (textSplit[0] == "Sheet")          sheet.SheetBy = textSplit[1];
            else if (textSplit[0] == "Difficult")      sheet.Difficult = textSplit[1];
            else if (sheetText == "[NoteInfo]")
            {
                sheetText = strReader.ReadLine();
                while (sheetText != null && !sheetText.StartsWith("["))
                {
                    textSplit = sheetText.Split(',');

                    int.TryParse(textSplit[0], out laneNumber);
                    float.TryParse(textSplit[2], out noteTime);

                    if (laneNumber == 64) laneNumber = 1;
                    else if (laneNumber == 192) laneNumber = 2;
                    else if (laneNumber == 320) laneNumber = 3;
                    else if (laneNumber == 448) laneNumber = 4;

                    sheet.SetNote(laneNumber, noteTime);

                    sheetText = strReader.ReadLine();
                }
            }

            sheetText = strReader.ReadLine();
        }
    }

}


