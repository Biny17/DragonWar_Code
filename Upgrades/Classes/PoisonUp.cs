using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "PoisonUp", menuName = "Upgrades/PoisonUp")]
public class PoisonUp : AbilityUpgrade
{
    public float durationUp = 0f;
    public int damageUp = 20;

    private Poison GetPoison(AbilityClass ability)
    {
        Poison poison = ability.effects.FirstOrDefault(effect => effect is Poison) as Poison;
        if(poison == null)
        {
            Debug.LogError("No poison to upgrade on ability");
        }
        return poison;
    }
    public override void UpgradeAbility(AbilityClass ability)
    {
        Poison poison = GetPoison(ability);
        poison.duration += durationUp;
        poison.totalDamage += damageUp;
    }

    public override string GetDescription(GameObject player)
    {
        Poison poison = GetPoison(GetAbility(player));
        string s = base.GetDescription(player);
        s += "Poison\n";
        if (damageUp != 0)
        s += $"damage:{poison.totalDamage}->{poison.totalDamage+damageUp}\n";
        if (durationUp != 0)
        s += $"duration:{poison.duration}->{poison.duration+durationUp}";
        return s;
    }

}