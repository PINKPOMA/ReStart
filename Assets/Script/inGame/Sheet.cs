using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheet : MonoBehaviour
{
    public string AudioFileName { set; get; }
    public string ImageFileName { set; get; }
    public string Title { set; get; }
    public string Artist { set; get; }
    public string Source { set; get; }
    public string SheetBy { set; get; }
    public string Difficult { set; get; }

    public List<float> noteList1;
    public List<float> noteList2;
    public List<float> noteList3;
    public List<float> noteList4;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetNote(int laneNumber, float noteTime)
    {
        if (laneNumber.Equals(1))
            noteList1.Add(noteTime);
        else if (laneNumber.Equals(2))
            noteList2.Add(noteTime);
        else if (laneNumber.Equals(3))
            noteList3.Add(noteTime);
        else if (laneNumber.Equals(4))
            noteList4.Add(noteTime);
    }
}