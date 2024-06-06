using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using UnityEngine.UI;


public class ShowAdScript : MonoBehaviour
{
    public YandexGame sdk;
    public int coinsAdd;
    public TMPro.TextMeshProUGUI coinsTxt;
    [SerializeField] DataContainer dataContainer;

    public void AdButton()
    {
        sdk._RewardedShow(1);
    }

    public void AdButtonCu1()
    {
        coinsAdd = 15;
        dataContainer.coins += coinsAdd;
        PlayerPrefs.SetInt("coins", dataContainer.coins);//

    }
    
}
