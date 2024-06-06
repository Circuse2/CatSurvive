using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using YG;

public class Saves : MonoBehaviour
{
    [SerializeField] DataContainer dataContainer;

    //PauseManager pauseManager;

    //private void Awake()
    //{
    //    pauseManager = GetComponent<PauseManager>();
    //}

    //private void Update()
    //{
    //    if ((YandexGame.nowFullAd == true) || (YandexGame.nowVideoAd == true))
    //    {
    //       pauseManager.PauseGame();
    //    }
    //    if ((YandexGame.nowFullAd == false) && (YandexGame.nowVideoAd == false))
    //    {
    //       pauseManager.UnPauseGame();
    //    }
    //}

    private void Start()
    {
 
        dataContainer.coins = PlayerPrefs.GetInt("coins");//
        //PlayerPrefs.DeleteAll();

    }
}
