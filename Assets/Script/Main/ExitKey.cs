using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitKey : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject selectSong = GameObject.Find("SelectSong");
            Destroy(selectSong);

            SceneManager.LoadScene("Title");
        }
    }
}