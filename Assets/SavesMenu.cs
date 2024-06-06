using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavesMenu : MonoBehaviour
{
    [SerializeField] DataContainer dataContainer;

    private void Awake()
    {
        dataContainer.coins = PlayerPrefs.GetInt("coins");
    }
}
