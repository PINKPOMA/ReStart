using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;
    public GameObject img;
    public GameObject bg;
    

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OpenSetting();
        }
    }

    public void SetLevel(float sliderValue)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume",sliderValue);
    }

    public void OpenSetting()
    {
        bg.SetActive(true);
        img.SetActive(true);
    }
    public void CloseSetting()
    {
        bg.SetActive(false);
        img.SetActive(false);
    }
    
}
