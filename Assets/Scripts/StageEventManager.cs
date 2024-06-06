using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    [SerializeField] StageData stageData;
    [SerializeField] EnemiesManager enemiesManager;

    StageTime stageTime;
    int eventIndexer;
    PlayerWinManager playerWin;

    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
    }

    public void Start()
    {
        playerWin = FindObjectOfType<PlayerWinManager>();
    }
    private void Update()
    {
        if (eventIndexer >= stageData.stageEvents.Count) { return; }

        if (stageTime.time > stageData.stageEvents[eventIndexer].time)
        {
            switch (stageData.stageEvents[eventIndexer].eventType)
            {
                case StageEvetType.SpawnEnemy:
                    for (int i = 0; i < stageData.stageEvents[eventIndexer].count; i++)
                    {
                        SpawEnemy();
                    }
                    break;
                case StageEvetType.SpawnObject:
                    for(int i = 0; i < stageData.stageEvents[eventIndexer].count; i++)
                    {
                        SpawnObject();
                    }
                    break;
                case StageEvetType.WinStage:
                    WinStage();
                    break;
            }

            
            eventIndexer += 1;
        }
    }

    private void WinStage()
    {
        playerWin.Win();
    }

    private void SpawEnemy()
    {
        enemiesManager.SpawnEnemy(stageData.stageEvents[eventIndexer].enemyToSpawn);
    }

    private void SpawnObject()
    {
        Vector3 positionToSpawn = GameManager.Instance.playerTransform.position;
        positionToSpawn += UtilityTools.GenerateRandomPositionSquarePattern(new Vector2(5f, 5f));

        SpawnManager.instance.SpawnObject(
                            positionToSpawn,
                            stageData.stageEvents[eventIndexer].objectToSpawn
                            );
    }
}
