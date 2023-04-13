using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class SongBoard : MonoBehaviour
{
    
    public Transform targetTransform;
    public SongItemBoard itemDisplayPrefab;
    private int scroll;

    public void Awake()
    {
        scroll = 0;
    }

    public void Prime(List<SongItem> items)
    {
        foreach(SongItem item in items)
        {
            SongItemBoard display = Instantiate(itemDisplayPrefab);
            display.transform.SetParent(targetTransform);
            display.transform.Translate(1220,440 + (scroll * 200),0);
            display.Prime(item);
            scroll++;   
        }


    }
}