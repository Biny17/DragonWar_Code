using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthPlus", menuName = "Upgrades/Healthplus")]
public class HealthPlus : Upgrade
{
    public int healthIncrease;
    public override void ApplyUpgrade(GameObject player)
    {
        Entity playerStat = player.GetComponent<Entity>();
        playerStat.AddMaxHealth(healthIncrease);
    }

    public override string GetDescription(GameObject player)
    {
        string s = $"Stats\n\nGain +{healthIncrease} health points";
        return s;
    }
}
