using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PenetrationUp", menuName = "Upgrades/PenetrationUp")]
public class PenetrationUp : AbilityUpgrade
{
    public int peneUp = 1;

    private ProjectileAbility CheckProjectileAbility(GameObject player)
    {
        AbilityClass ability = GetAbility(player);
        if (ability is ProjectileAbility)
        {
            return ability as ProjectileAbility;
        } else
        {
            Debug.LogError("Tried to upgrade penetration of a non ProjectileAbility");
            return null;
        }
    }

    public override string GetDescription(GameObject player)
    {
        ProjectileAbility ability = CheckProjectileAbility(player);
        string s = base.GetDescription(player);
        s += $"Go through {ability.penetration}->{ability.penetration+peneUp} ennemies";
        return s;
    }

    public override void UpgradeAbility(AbilityClass ability)
    {
        ProjectileAbility projectileAbility = ability as ProjectileAbility;
        projectileAbility.penetration += peneUp;
    }
}