using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GG : MonoBehaviour
{

    public SpriteRenderer tee;
    private void Start()
    {
        StartCoroutine("BG");
    }


    IEnumerator BG()
    {
        tee.DOFade(0.25f, 1.5f);
        yield return new WaitForSeconds(1.5f);
        tee.DOFade(0.5f, 1.5f);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine("BG");
    }
}
