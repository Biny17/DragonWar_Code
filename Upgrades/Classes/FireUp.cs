using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "BurnUp", menuName = "Upgrades/BurnUp")]
public class BurnUp : AbilityUpgrade
{
    public float durationUp = 0f;
    public int damageUp = 40;

    private Burn GetBurn(AbilityClass ability)
    {
        Burn burn = ability.effects.FirstOrDefault(effect => effect is Burn) as Burn;
        if(burn == null)
        {
            Debug.LogError("No Burn to upgrade on ability");
        }
        return burn;
    }
    public override void UpgradeAbility(AbilityClass ability)
    {
        Burn burn = GetBurn(ability);
        burn.duration += durationUp;
        burn.totalDamage += damageUp;
    }

    public override string GetDescription(GameObject player)
    {
        Burn burn = GetBurn(GetAbility(player));
        string s = base.GetDescription(player);
        s += "Burn\n";
        if (damageUp != 0)
            s += $"damage:{burn.totalDamage}->{burn.totalDamage+damageUp}\n";
        if (durationUp != 0)
            s += $"duration:{burn.duration}->{burn.duration+durationUp}";
        return s;
    }
}