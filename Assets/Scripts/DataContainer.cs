using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerPersistentUpgrades
{
    Здоровье,
    Урон,
    ДальностьАтаки,
    СкоростьПередвижения,
    Броня,
    БонусныйОпыт
}

[Serializable]
public class PlayerUpgrades
{
    public PlayerPersistentUpgrades persistentUpgrades;

    public int level = 0;
    public int costToUpgrade = 10;

}

[CreateAssetMenu]
public class DataContainer : ScriptableObject
{
    public int coins;

    public List<bool> stageCompletion;

    public List<PlayerUpgrades> upgrades;

    public bool isPlayerNew;

    public void StageComplete(int i)
    {
        stageCompletion[i] = true;
    }

    public int GetUpgradeLevel(PlayerPersistentUpgrades persistentUpgrade)
    {
       
        upgrades[(int)persistentUpgrade].level = PlayerPrefs.GetInt(persistentUpgrade.ToString());//upgrades[(int)persistentUpgrade].ToString()
        return upgrades[(int)persistentUpgrade].level;
            
    }
}
