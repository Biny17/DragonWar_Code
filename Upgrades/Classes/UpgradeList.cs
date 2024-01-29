using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeList", menuName = "UpgradesList")]
public class UpgradeList : ScriptableObject
{
    public List<Upgrade> upgrades;
}
