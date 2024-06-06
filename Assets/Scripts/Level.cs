using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Level : MonoBehaviour
{
    int level = 1;
    int experience = 0;

    [SerializeField] ExperienceBar experienceBar;
    [SerializeField] UpgradePanelManager upgradePanel;

    [SerializeField] List<UpgradeData> upgrades;
    List<UpgradeData> selectedUpgrades;

    [SerializeField] List<UpgradeData> acquiredUpgrades;

    PassiveItems passiveItems;

    [SerializeField] List<UpgradeData> upgradesAvaibaleOnStart;//
    public Animator animator;

    public AudioClip levelUpSoud;
    MusicManager musicManager;

    private void Awake()
    {
        passiveItems = GetComponent<PassiveItems>();
        musicManager = FindObjectOfType<MusicManager>();
    }
    int TO_LEVEL_UP
    {
        get { return level * 1000; }
    }

    internal void AddUpgradesIntoTheListOfAvailableUpgrades(List<UpgradeData> upgradesToAdd)
    {
        if(upgradesToAdd == null) { return; }
        this.upgrades.AddRange(upgradesToAdd);
    }

    private void Start()
    {
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        experienceBar.SetLevelText(level);

        AddUpgradesIntoTheListOfAvailableUpgrades(upgradesAvaibaleOnStart);
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }

    public void Upgrade(int selectedUpgradeId)
    {
        UpgradeData upgradeData = selectedUpgrades[selectedUpgradeId];

        if (acquiredUpgrades == null) { acquiredUpgrades= new List<UpgradeData>(); }

        switch (upgradeData.upgradeType)
        {
            case UpgradeType.ItemUnlock:
                passiveItems.Equip(upgradeData.item);
                AddUpgradesIntoTheListOfAvailableUpgrades(upgradeData.item.upgrades);
                break;
            case UpgradeType.ItemUpgrade:
                passiveItems.UpgradeItem(upgradeData);
                break;
        }

        acquiredUpgrades.Add(upgradeData);
        upgrades.Remove(upgradeData);

        
    }

    public void CheckLevelUp()
    {
        if(experience >= TO_LEVEL_UP)
        {
            animator.SetTrigger("LevelUpTrigger");
            LevelUp();
        }
    }

    private void LevelUp()
    {
        GetComponent<Character>().LiderBordUpdate();//
        if (selectedUpgrades == null) { selectedUpgrades = new List<UpgradeData>(); }
        selectedUpgrades.Clear();
        selectedUpgrades.AddRange(GetUpgrades(3));

        upgradePanel.OpenPanel(selectedUpgrades);
        experience -= TO_LEVEL_UP;
        level += 1;
        experienceBar.SetLevelText(level);
        musicManager.Play(levelUpSoud);
    }

    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();


        if (count > upgrades.Count)
        {
            count = upgrades.Count;
        }

        for (int i = 0;i<count; i++)
        {
            upgradeList.Add(upgrades[Random.Range(0, upgrades.Count)]);
        }

        return upgradeList;
    }
}
