using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing.Security;
using static Cinemachine.DocumentationSortingAttribute;

public class CoinPickUp : MonoBehaviour, IPickUpObject
{
    [SerializeField] int count;

    public AudioClip CoinPickUpSoud;
    MusicManager musicManager;

    int totalcoins;//


    private void Awake()
    {
        musicManager = FindObjectOfType<MusicManager>(); 
    }
    public void OnPickUp(Character character)
    {
        musicManager.Play(CoinPickUpSoud);
        character.coins.Add(count);
        int totalCoins = PlayerPrefs.GetInt("coins");//
        PlayerPrefs.SetInt("coins", count + totalCoins);//
    }
    
}
