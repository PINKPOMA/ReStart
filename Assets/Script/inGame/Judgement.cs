using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Judgement : MonoBehaviour
{
    Sheet sheet;
    Score score;
    SongManager songManager;

    float currentTime;
    float currentNoteTime1;
    float currentNoteTime2;
    float currentNoteTime3;
    float currentNoteTime4;

    float greatRate = 3025f;
    float goodRate = 7050f;
    float missRate = 16100f;

    int laneNum;

    Queue<float> judgeLane1 = new Queue<float>();
    Queue<float> judgeLane2 = new Queue<float>();
    Queue<float> judgeLane3 = new Queue<float>();
    Queue<float> judgeLane4 = new Queue<float>();

    public GameObject efk1;
    public GameObject efk2;
    public GameObject efk3;
    public GameObject efk4;

    private SpriteRenderer ek1r;
    private SpriteRenderer ek2r;
    private SpriteRenderer ek3r;
    private SpriteRenderer ek4r;
    
    public ParticleSystem k1;
    public ParticleSystem k2;
    public ParticleSystem k3;
    public ParticleSystem k4;
    void Start()
    {
        ek1r = efk1.GetComponent<SpriteRenderer>();
        ek2r = efk2.GetComponent<SpriteRenderer>();
        ek3r = efk3.GetComponent<SpriteRenderer>();
        ek4r = efk4.GetComponent<SpriteRenderer>();
        k1.Stop();
        k2.Stop();
        k3.Stop();
        k4.Stop();
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();
        SetQueue();
        songManager = GameObject.Find("SelectSong").GetComponent<SongManager>();
        score = GameObject.Find("Score").GetComponent<Score>();
    }

    void Update()
    {
        
        currentTime = songManager.music.timeSamples;
        if (judgeLane1.Count > 0)
        {
            currentNoteTime1 = judgeLane1.Peek();
            currentNoteTime1 = currentNoteTime1 * 0.001f * songManager.music.clip.frequency;
        }
        
        if (judgeLane2.Count > 0)
        {
            currentNoteTime2 = judgeLane2.Peek();
            currentNoteTime2 = currentNoteTime2 * 0.001f * songManager.music.clip.frequency;
        }
        
        if (judgeLane3.Count > 0)
        {
            currentNoteTime3 = judgeLane3.Peek();
            currentNoteTime3 = currentNoteTime3 * 0.001f * songManager.music.clip.frequency;
        }
        
        if (judgeLane4.Count > 0)
        {
            currentNoteTime4 = judgeLane4.Peek();
            currentNoteTime4 = currentNoteTime4 * 0.001f * songManager.music.clip.frequency;
        }
    }

    public void JudgeNote(int laneNum)
    {
        this.laneNum = laneNum;

        if (laneNum.Equals(1))
        {
            if (Mathf.Abs(currentNoteTime1 - currentTime) <= greatRate)
            {
                StopCoroutine("ef1down");
                ek1r.color = new Color(1, 0.8796933f, 0.5607843f, 1);
                StartCoroutine("ef1down");

                k1.startColor = new Color(1, 0.8796933f, 0.5607843f, 1);
                k1.time = 0;
                k1.Play();
                judgeLane1.Dequeue();
                score.ProcessScore(2);

            }
            else if (Mathf.Abs(currentNoteTime1 - currentTime) <= goodRate)
            {
                StopCoroutine("ef1down");
                ek1r.color = new Color(0.8117647f, 1, 0.5843138f, 1);
                StartCoroutine("ef1down");

                k1.startColor = new Color(0.8117647f, 1, 0.5843138f, 1);
                k1.time = 0;
                k1.Play();
                judgeLane1.Dequeue();
                score.ProcessScore(1);
            }
            else if (currentNoteTime1 + missRate <= currentTime)
            {
                judgeLane1.Dequeue();
                score.ProcessScore(0);
            }
        }


        if (laneNum.Equals(2))
        {
            if (Mathf.Abs(currentNoteTime2 - currentTime) <= greatRate)
            {
                StopCoroutine("ef2down");
                ek2r.color = new Color(1, 0.8796933f, 0.5607843f, 1);
                StartCoroutine("ef2down");

                k2.startColor = new Color(1, 0.8796933f, 0.5607843f, 1);
                k2.time = 0;
                k2.Play();
                judgeLane2.Dequeue();
                score.ProcessScore(2);
            }
            else if (Mathf.Abs(currentNoteTime2 - currentTime) <= goodRate)
            {
                StopCoroutine("ef2down");
                ek2r.color = new Color(0.8117647f, 1, 0.5843138f, 1);
                StartCoroutine("ef2down");

                k2.startColor = new Color(0.8117647f, 1, 0.5843138f, 1);
                k2.time = 0;
                k2.Play();
                judgeLane2.Dequeue();
                score.ProcessScore(1);
            }
            else if (currentNoteTime2 + missRate <= currentTime)
            {
                judgeLane2.Dequeue();
                score.ProcessScore(0);
            }
        }


        if (laneNum.Equals(3))
        {

            if (Mathf.Abs(currentNoteTime3 - currentTime) <= greatRate)
            {
                StopCoroutine("ef3down");
                ek3r.color = new Color(1, 0.8796933f, 0.5607843f, 1);
                StartCoroutine("ef3down");

                k3.startColor = new Color(1, 0.8796933f, 0.5607843f, 1);
                k3.time = 0;
                k3.Play();
                judgeLane3.Dequeue();
                score.ProcessScore(2);
            }
            else if (Mathf.Abs(currentNoteTime3 - currentTime) <= goodRate)
            {
                StopCoroutine("ef3down");
                ek3r.color = new Color(0.8117647f, 1, 0.5843138f, 1);
                StartCoroutine("ef3down");

                k3.startColor = new Color(0.8117647f, 1, 0.5843138f, 1);
                k3.time = 0;
                k3.Play();
                judgeLane3.Dequeue();
                score.ProcessScore(1);
            }
            else if (currentNoteTime3 + missRate <= currentTime)
            {
                judgeLane3.Dequeue();
                score.ProcessScore(0);
            }
        }


        if (laneNum.Equals(4))
        {
            if (Mathf.Abs(currentNoteTime4 - currentTime) <= greatRate)
            {
                StopCoroutine("ef4down");
                ek4r.color = new Color(1, 0.8796933f, 0.5607843f, 1);
                StartCoroutine("ef4down");

                k4.startColor = new Color(1, 0.8796933f, 0.5607843f, 1);
                k4.time = 0;
                k4.Play();
                judgeLane4.Dequeue();
                score.ProcessScore(2);
            }
            else if (Mathf.Abs(currentNoteTime4 - currentTime) <= goodRate)
            {
                StopCoroutine("ef4down");
                ek4r.color = new Color(0.8117647f, 1, 0.5843138f, 1);
                StartCoroutine("ef4down");

                k4.startColor = new Color(0.8117647f, 1, 0.5843138f, 1);
                k4.time = 0;
                k4.Play();
                judgeLane4.Dequeue();
                score.ProcessScore(1);
            }
            else if (currentNoteTime4 + missRate <= currentTime)
            {
                judgeLane4.Dequeue();
                score.ProcessScore(0);
            }
        }


    }

    void SetQueue()
    {
        foreach (float noteTime in sheet.noteList1)
            judgeLane1.Enqueue(noteTime + 100);
        foreach (float noteTime in sheet.noteList2)
            judgeLane2.Enqueue(noteTime+ 100);
        foreach (float noteTime in sheet.noteList3)
            judgeLane3.Enqueue(noteTime+ 100);
        foreach (float noteTime in sheet.noteList4)
            judgeLane4.Enqueue(noteTime+ 100);
    }

   
    IEnumerator ef1down()
    {
        Color ek1RColor = ek1r.color;
        for (int i = 1; i <= 10; i++)
        {
            ek1RColor.a -= 0.1f;
            ek1r.color = ek1RColor; 
            yield return new WaitForSeconds(0.1f);
        }
        
    }
    IEnumerator ef2down()
    {
        Color ek2RColor = ek2r.color;
        for (int i = 1; i <= 10; i++)
        {
            ek2RColor.a -= 0.1f;
            ek2r.color = ek2RColor; 
            yield return new WaitForSeconds(0.1f);
        }
        
    }
    IEnumerator ef3down()
    {
        Color ek3RColor = ek3r.color;
        for (int i = 1; i <= 10; i++)
        {
            ek3RColor.a -= 0.1f;
            ek3r.color = ek3RColor; 
            yield return new WaitForSeconds(0.1f);
        }
        
    }
    IEnumerator ef4down()
    {
        Color ek4RColor = ek4r.color;
        for (int i = 1; i <= 10; i++)
        {
            ek4RColor.a -= 0.1f;
            ek4r.color = ek4RColor; 
            yield return new WaitForSeconds(0.1f);
        }
        
    }
    
}


