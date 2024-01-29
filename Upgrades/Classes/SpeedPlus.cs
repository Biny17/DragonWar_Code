using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedPlus", menuName = "Upgrades/SpeedPlus")]
public class SpeedPlus : Upgrade
{
    public float speedIncrease = 0.2f;
    public override void ApplyUpgrade(GameObject player)
    {
        Entity playerStat = player.GetComponent<Entity>();
        playerStat.AddSpeedFlat(speedIncrease);
    }

    public override string GetDescription(GameObject player)
    {
        float oldSpeed = player.GetComponent<Entity>().GetSpeed()*100;
        float newSpeed = oldSpeed + speedIncrease*100;
        
        return $"Speed increase\n{oldSpeed:F0}->{newSpeed}";
    }
}