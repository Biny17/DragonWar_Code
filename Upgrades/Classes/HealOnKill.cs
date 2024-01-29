using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealOnKill", menuName = "Upgrades/HealOnKill")]
public class HealOnKill : AbilityUpgrade
{
    public int healAmount = 10;
    public void Heal(AbilityClass ability)
    {
        ability.owner.Heal(healAmount);
    }

    public override void UpgradeAbility(AbilityClass ability)
    {
        ability.onKill += Heal;
    }

    public override string GetDescription(GameObject player)
    {
        string s = base.GetDescription(player);
        s += $"Heal {healAmount}hp on ennemy killed";
        return s;
    }
}