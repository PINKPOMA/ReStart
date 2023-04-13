using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    Score score;
    Sheet sheet;
    
    Image spriteSongImg;
    Text textSongName;
    Text textSongSheet;
    Text textSongLevel;
    Text textSongJudge;
    Text textSongCombo;
    Text textSongScore;
    Text textSongTire;
    Text textAC;
    
    private int mxNode;
    private float tire;
    void Start()
    {
        mxNode = 0;
        score = GameObject.Find("Score").GetComponent<Score>();
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();

        spriteSongImg = GameObject.Find("SongImg").GetComponent<Image>();
        textSongName = GameObject.Find("SongName").GetComponent<Text>();
        textSongJudge = GameObject.Find("SongJudge").GetComponent<Text>();
        textSongCombo = GameObject.Find("SongCombo").GetComponent<Text>();
        textSongScore = GameObject.Find("SongScore").GetComponent<Text>();
        textSongTire = GameObject.Find("Tiretext").GetComponent<Text>();
        textAC = GameObject.Find("Accuracy").GetComponent<Text>();

        spriteSongImg.sprite = Resources.Load<Sprite>(sheet.Title + "/" + sheet.ImageFileName) as Sprite;
        

        textSongName.text = sheet.Title;
        
        StringBuilder judge = new StringBuilder();
        judge.Append("Perfect   ");
        judge.Append(score.GreatCnt.ToString());
        judge.Append("\n");
        judge.Append("GOOD    ");
        judge.Append(score.GoodCnt.ToString());
        judge.Append("\n");
        judge.Append("MISS       ");
        judge.Append(score.MissCnt.ToString());
        textSongJudge.text = judge.ToString();

        textSongCombo.text = "MAX Combo  " + score.MaxCombo;
        textSongScore.text = "점수   " + score.SongScore;
        Rank();
    }
    
    void Rank()
    {
        mxNode += score.GoodCnt;
        mxNode += score.GreatCnt;
        mxNode += score.MissCnt;

        tire = score.SongScore / mxNode;

        if (tire >= 95)
        {
            textSongTire.text = "S";
        }
        else if (tire >= 90)
        {
            textSongTire.text = "A";
        }
        else if (tire >= 80)
        {
            textSongTire.text = "B";
        }
        else if (tire >= 70)
        {
            textSongTire.text = "C";
        }     
        else if (tire <= 69)
        {
            textSongTire.text = "F";
        }
        
        textAC.text = string.Format("{0:0.#}",tire) + "%";
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            SelectSong();
        }
    }


    void SelectSong()
    {
        GameObject sheet = GameObject.Find("Sheet");
        GameObject score = GameObject.Find("Score");
        GameObject songSelect = GameObject.Find("SelectSong");
        Destroy(sheet);
        Destroy(score);
        Destroy(songSelect);

        SceneManager.LoadScene("Main");
    }

}
