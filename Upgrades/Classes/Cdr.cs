using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cdr", menuName = "Upgrades/Cdr")]
public class Cdr : AbilityUpgrade
{
    public int CoolDownReduction = 10;
    public override void UpgradeAbility(AbilityClass ability)
    {
        ability.CdReduction += CoolDownReduction;
    }
    public override string GetDescription(GameObject player)
    {
        string s = base.GetDescription(player);
        s += $"+{CoolDownReduction} CoolDown Reduction";
        return s;
    }
}