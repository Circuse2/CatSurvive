using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton1 : MonoBehaviour
{
    public AudioClip Button1Soud;
    MusicManager musicManager;

    private void Awake()
    {
        musicManager = FindObjectOfType<MusicManager>();
    }

    public void ButtonOneSoundClick()
    {
        musicManager.Play(Button1Soud);
    }
}
