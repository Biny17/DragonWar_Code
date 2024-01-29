using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StopToCast", menuName = "Upgrades/StopToCast")]
public class StopToCast : AbilityUpgrade
{
    public float DamageMultiplier;
    public float CdMultiplier;

    public override string GetDescription(GameObject player)
    {
        AbilityClass ability = GetAbility(player);
        string s = $"Stop Moving for {AbilityName} to cast\n";
        s += $"Damage: {ability.GetDmg(ability.Dmg)}->{(int)(ability.GetDmg(ability.Dmg)*DamageMultiplier)}\n";
        s += $"CoolDown: {ability.CdBase}->{ability.CdBase*CdMultiplier}";
        return s;
    }

    public override void UpgradeAbility(AbilityClass ability)
    {
        ability.damageOutput.percent *= 1.5f;
        ability.CdBase *= CdMultiplier;
        ability.StopCast = true;
    }
}