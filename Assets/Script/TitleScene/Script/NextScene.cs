using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextScene : MonoBehaviour
{
    [SerializeField] private Text pressKey;

    private void Start()
    {
        StartCoroutine(Breath());
    }

    IEnumerator Breath()
    {
        pressKey.DOFade(0, 1.5f);
        yield return new WaitForSeconds(2f);
        pressKey.DOFade(1, 3f);
        yield return new WaitForSeconds(3f);
        StartCoroutine(Breath());
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
