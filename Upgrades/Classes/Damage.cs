using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage", menuName = "Upgrades/Damage")]
public class Damage : AbilityUpgrade
{
    public int amount;

    public override string GetDescription(GameObject player)
    {
        AbilityClass ability = GetAbility(player);
        string s = base.GetDescription(player);
        s+= $"Damage: {ability.Dmg}->{ability.Dmg+amount}";
        return s;
    }

    public override void UpgradeAbility(AbilityClass ability)
    {
        ability.Dmg += amount;
    }
}