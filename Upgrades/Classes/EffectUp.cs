using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectUp", menuName = "Upgrades/EffectUp")]
public class EffectUp : AbilityUpgrade
{
    public Effect effect;

    public override string GetDescription(GameObject player)
    {
        string s = $"{AbilityName}\n\n";
        s += effect.Description();
        return s;
    }

    public override void UpgradeAbility(AbilityClass ability)
    {
        ability.effects.Add(effect);
    }
}