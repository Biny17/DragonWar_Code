using System;
using System.Collections.Generic;
using UnityEngine;


public abstract class AbilityUpgrade : Upgrade
{
    public abilities AbilityName;

    public override void ApplyUpgrade(GameObject player)
    {
        AbilityClass ability = GetAbility(player);
        ability.Upgrades.Add(this);
        UpgradeAbility(ability);
    }

    public AbilityClass GetAbility(GameObject player)
    {
        Type abilityType = Type.GetType(AbilityName.ToString());
        AbilityClass ability = player.GetComponentInChildren(abilityType) as AbilityClass;
        if (ability == null)
        {
            Debug.LogError("ABILITY NOT FOUND AAAAAAAAAAA");
            return null;
        }
        return ability;
    }
    public abstract void UpgradeAbility(AbilityClass ability);

    public override string GetDescription(GameObject player)
    {
        string s = $"{AbilityName}\n\n";
        return s;
    }
}