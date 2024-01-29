using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SlowUp", menuName = "Upgrades/SlowUp")]
public class SlowUp : AbilityUpgrade
{
    public float durationUp = 1f;
    public int slowUp = 20;

    private Slow GetSlow(AbilityClass ability)
    {
        Slow slow = ability.effects.FirstOrDefault(effect => effect is Slow) as Slow;
        if(slow == null)
        {
            Debug.LogError("No Slow to upgrade on ability");
        }
        return slow;
    }
    public override void UpgradeAbility(AbilityClass ability)
    {
        Slow slow = GetSlow(ability);
        slow.duration += durationUp;
        slow.slowPercentage += slowUp;
    }

    public override string GetDescription(GameObject player)
    {
        Slow slow = GetSlow(GetAbility(player));
        string s = base.GetDescription(player);
        s += "Slow\n";
        if (slowUp != 0)
            s += $"slow:{slow.slowPercentage}->{slow.slowPercentage+slowUp}\n";
        if (durationUp != 0)
            s += $"duration:{slow.duration}->{slow.duration+durationUp}";
        return s;
    }
}