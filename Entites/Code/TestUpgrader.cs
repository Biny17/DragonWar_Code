using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUpgrader : MonoBehaviour
{
    public List<Upgrade> upgrades;

    void Start()
    {
        foreach(Upgrade upgrade in upgrades)
        {
            upgrade.ApplyUpgrade(Player.instance.gameObject);
        }
    }    
}
