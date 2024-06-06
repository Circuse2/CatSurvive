using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using static UnityEngine.Rendering.DebugUI;

public class WelcomeGamePanelScript : MonoBehaviour
{
    [SerializeField] GameObject WelcomePanel;
    [SerializeField] DataContainer dataContainer;
    PauseManager pauseManager;


    private void Awake()
    {
        pauseManager = GetComponent<PauseManager>();
    }

    private void Start()
    {
        if (YandexGame.nowFullAd == false)
        { pauseManager.UnPauseGame(); }
        if (dataContainer.isPlayerNew == false)
        {
            pauseManager.PauseGame();
            WelcomePanel.SetActive(true);
            dataContainer.isPlayerNew = true;
        }
    }

    public void CloseMenu()
    {
        pauseManager.UnPauseGame();
        WelcomePanel.SetActive(false);
    }

}
