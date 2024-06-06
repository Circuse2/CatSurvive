using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StageEvetType
{
    SpawnEnemy,
    SpawnObject,
    WinStage
}

[Serializable]
public class StageEvent
{
    public StageEvetType eventType;

    public float time;
    public string message;

    public EnemyData enemyToSpawn;
    public GameObject objectToSpawn;
    public int count;
}

[CreateAssetMenu]
public class StageData : ScriptableObject
{
   public List<StageEvent> stageEvents;
}
