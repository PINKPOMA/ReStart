using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text textScore;
    Text textJudge;
    Text textCombo;

    public int SongScore { private set; get; }
    public int MissCnt { private set; get; }
    public int GoodCnt { private set; get; }
    public int GreatCnt { private set; get; }
    public int Combo { private set; get; }
    public int MaxCombo { private set; get; }

    string strJudge;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        textScore = GameObject.Find("ScoreText").GetComponent<Text>();
        textJudge = GameObject.Find("Judge").GetComponent<Text>();
        textCombo = GameObject.Find("Combo").GetComponent<Text>();

        SongScore = 0;
        Combo = 0;
        MissCnt = 0;
        GoodCnt = 0;
        GreatCnt = 0;
        MaxCombo = 0;

        strJudge = "";
    }

    public void ProcessScore(int judge)
    {
        if(judge.Equals(0))
        {
            strJudge = "MISS";
            Combo = 0;
            MissCnt++;
            textJudge.color = Color.gray;
        }
        else if(judge.Equals(1))
        {
            SongScore += 50;
            strJudge = "GOOD";
            Combo++;
            GoodCnt++;
            textJudge.color = Color.yellow;
        }
        else if(judge.Equals(2))
        {
            SongScore += 100;
            strJudge = "PERFECT";
            Combo++;
            GreatCnt++;
            textJudge.color = new Color(0.535799f,0.5320755f,1,1);
        }
      
        SetMaxCombo();
        SetTextScore();
    }

    void SetMaxCombo()
    {
        if (Combo > MaxCombo)
            MaxCombo = Combo;
    }

    void SetTextScore()
    {
        textScore.text = SongScore.ToString();
        textJudge.text = strJudge;
        textCombo.color = Color.white;
        textCombo.text = Combo.ToString();
        
    }
}
