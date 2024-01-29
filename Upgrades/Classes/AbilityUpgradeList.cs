using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityUpgradeList", menuName = "Scriptable/AbilityUpgradeList")]
public class AbilityUpgradeList : ScriptableObject
{
    public abilities abilityName;
    public List<AbilityUpgrade> upgrades;


    private void OnValidate()
    {
        foreach(AbilityUpgrade uppies in upgrades)
        {
            if (uppies != null && uppies.AbilityName != abilityName)
            {
                Debug.LogError($"{uppies.name}'s AbilityName: {uppies.AbilityName} didn't match {abilityName}");
            }
        }
    }
}
