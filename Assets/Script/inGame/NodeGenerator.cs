using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class NodeGenerator : MonoBehaviour
{
    Sheet sheet;

    public GameObject notePrefab;
    public GameObject note2Prefab;

    float noteCorrectRate = 0.001f; 

    float notePosY;
    float noteStartPosY;
    float offset;
    public float scrollSpeed;  

    public bool isGenFin;
    
    void Start()
    {
        scrollSpeed = 17f;
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();
        notePosY = scrollSpeed;
        noteStartPosY = scrollSpeed * 3.0f;
    }

    void Update()
    {
        if (isGenFin.Equals(false))
        {
            GenNote();
            isGenFin = true;
        }
    }
    
   void GenNote()
   {
       GenNoteList(sheet.noteList1, notePrefab, new Vector3(-3f, 0f, 0f));
       GenNoteList(sheet.noteList2, note2Prefab, new Vector3(-1f, 0f, 0f));
       GenNoteList(sheet.noteList3, note2Prefab, new Vector3(1f, 0f, 0f));
       GenNoteList(sheet.noteList4, notePrefab, new Vector3(3f, 0f, 0f));
   }
    
   void GenNoteList(List<float> noteList, GameObject notePrefab, Vector3 positionOffset)
   {
       float posY;
       foreach(float noteTime in noteList)
       {
           posY = noteStartPosY + notePosY * (noteTime * noteCorrectRate) + positionOffset.y;
           Instantiate(notePrefab, new Vector3(positionOffset.x, posY, positionOffset.z), Quaternion.identity);
       }
   }
}