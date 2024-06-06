using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class ItemStats
{
    public int armor;
    public int hp;
    public float attackRange;
    public int attackDamage;
    public int bonusExperienceAmount;

    internal void Sum(ItemStats stats)
    {
        armor += stats.armor;
        hp += stats.hp;
        attackRange += stats.attackRange;
        attackDamage += stats.attackDamage;
        bonusExperienceAmount += stats.bonusExperienceAmount;
    }
}

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public ItemStats stats;
    public List<UpgradeData> upgrades;

    public void Init(string Name)
    {
        this.Name = Name;
        stats = new ItemStats();
        upgrades = new List<UpgradeData>();
    }

    public void Equip(Character character)
    {
        character.armor += stats.armor;

        character.maxHp += stats.hp;
        character.currentHp += stats.hp;

        character.attackRange += stats.attackRange;

        character.attackDamage += stats.attackDamage;

        character.bonusExperienceAmount += stats.bonusExperienceAmount;


    }

    public void UnEquip(Character character)
    {
        character.armor -= stats.armor;

        character.maxHp -= stats.hp;
        character.currentHp -= stats.hp;

        character.attackRange -= stats.attackRange;

        character.attackDamage -= stats.attackDamage;

        character.bonusExperienceAmount -= stats.bonusExperienceAmount;
    }
}
