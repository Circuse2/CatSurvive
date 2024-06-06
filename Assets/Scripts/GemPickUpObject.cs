using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickUpObject : MonoBehaviour, IPickUpObject
{
    [SerializeField] int amount = 500;

    public AudioClip ExpPickUpSoud;
    MusicManager musicManager;


    private void Awake()
    {
        musicManager = FindObjectOfType<MusicManager>();
    }

    public void OnPickUp(Character character)
    {
        musicManager.Play(ExpPickUpSoud);
        amount += character.bonusExperienceAmount;//non effective
        character.level.AddExperience(amount);
    }
}
