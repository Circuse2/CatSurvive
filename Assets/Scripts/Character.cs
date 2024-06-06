using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using YG;

public class Character : MonoBehaviour
{
    public int maxHp = 1000;
    public int currentHp = 1000;

    public int armor = 0;

    public float attackRange = 0.7f;
    public int attackDamage = 40;
    public int bonusExperienceAmount = 0;

    public int enemyKilled = 0;

    public int damageBonus;

    [SerializeField] StatusBar hpBar;

    [HideInInspector] public Level level;
    [HideInInspector] public Coins coins;
    private bool isDead;

    [SerializeField] DataContainer dataContainer;

    public Animator animator;

    private void Awake()
    {
        level = GetComponent<Level>();
        coins = GetComponent<Coins>();

        enemyKilled = PlayerPrefs.GetInt("LiderBordLevel");//
    }

    private void Start()
    {
        ApplyPersistantUpgrades();
        hpBar.SetState(currentHp, maxHp);
    }

    public void ApplyPersistantUpgrades()
    {
        int hpUpgradeLevel = dataContainer.GetUpgradeLevel(PlayerPersistentUpgrades.Здоровье);
        maxHp += 20 * hpUpgradeLevel;
        currentHp = maxHp;

        int damageUpgradeLevel = dataContainer.GetUpgradeLevel(PlayerPersistentUpgrades.Урон);
        damageBonus = 5 * damageUpgradeLevel;

        int armorUpgradeLevel = dataContainer.GetUpgradeLevel(PlayerPersistentUpgrades.Броня);
        armor += armorUpgradeLevel;

        float attackRangeUpgradeLevel = dataContainer.GetUpgradeLevel(PlayerPersistentUpgrades.ДальностьАтаки);
        attackRange += attackRangeUpgradeLevel * 0.05f;

        int xpAmountUpgradeLevel = dataContainer.GetUpgradeLevel(PlayerPersistentUpgrades.БонусныйОпыт);
        bonusExperienceAmount += 50 * xpAmountUpgradeLevel; 
    }

    public void TakeDamage(int damage)
    {
        if (isDead == true) { return; }
        ApplyArmor(ref damage);

        animator.SetTrigger("TakeDamageTrigger");


        currentHp -= damage;

        if (currentHp <= 0)
        {
            GetComponent<CharacterGameOver>().GameOver();
            isDead = true;
        }
        hpBar.SetState(currentHp, maxHp);
    }

    private void ApplyArmor(ref int damage)
    {
        damage -= armor;
        if(damage < 0) { damage = 0; }
    }

    public void Heal(int amount)
    {
        if (currentHp <= 0) { return; }

        currentHp += amount;
        if (currentHp > maxHp)
        {
            currentHp= maxHp;
        }
        hpBar.SetState(currentHp, maxHp);
    }

    public void LiderBordUpdate()
    {
        enemyKilled += 1;
        YandexGame.NewLeaderboardScores("LiderBordDefeated", enemyKilled);//
        PlayerPrefs.SetInt("LiderBordLevel", enemyKilled);//
    }

}
