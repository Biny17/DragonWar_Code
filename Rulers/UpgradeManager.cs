using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Scripts;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeManager : MonoBehaviour
{
    public AbilityUpgradeList Ability1Upgrades;
    public AbilityUpgradeList Ability2Upgrades;
    public UpgradeList playerUpgrades;
    [HideInInspector] public List<Upgrade> upgradesApplied;
    [HideInInspector] public List<Upgrade> AllUpgrade = new List<Upgrade>();
    [HideInInspector] public List<Upgrade> picked;
    private List<GameObject> tiles;

    void Start()
    {
        upgradesApplied = GameData.appliedUpgrades;
        AllUpgrade.AddRange(Ability1Upgrades.upgrades);
        AllUpgrade.AddRange(Ability2Upgrades.upgrades);
        AllUpgrade.AddRange(playerUpgrades.upgrades);
        tiles = GetComponent<TileSelection>().tiles;
        ShowUpgrade();
    }
    public List<Upgrade> AvailableUpgrades()
    {
        List<Upgrade> Available = AllUpgrade.Except(upgradesApplied).ToList();
        foreach(Upgrade upgrade in Available.ToList())
        {
            if (CheckRequirement(upgrade) != true)
            {
                Available.Remove(upgrade);
            }
        }
        return Available;
    }

    public bool CheckRequirement(Upgrade upgrade)
    {
        return upgrade.requirements.All(item => upgradesApplied.Contains(item));
    }

    void ShowUpgrade()
    {
        picked = AvailableUpgrades().choice(4);
        for (int i = 0; i < picked.Count; i++)
        {
            var uI = tiles[i].GetComponent<UpgradeUI>();
            if (uI == null) Debug.LogError("Upgrade UI not found");
            uI.ChangeText(picked[i].GetDescription(Player.instance.gameObject));
            uI.ChangeImg(picked[i].icon);
        }
    }
    public void SelectUpgrade(int i)
    {
        // there will be an error is the player choose a empty upgrade tiles
        picked[i].ApplyUpgrade(Player.instance.gameObject);
        upgradesApplied.Add(picked[i]);
        GameManager.Instance.LoadLevelScene();
    }
}
