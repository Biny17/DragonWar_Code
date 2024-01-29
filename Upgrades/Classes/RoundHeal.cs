using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "RoundHeal", menuName = "Upgrades/RoundHeal")]
public class RoundHeal : RoundUpgrade
{
    public int healAmount = 30;
    public override void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "PowerupSelection")
        {
            Player.instance.GetComponent<Entity>().Heal(healAmount);
        }
    }

    public override string GetDescription(GameObject player)
    {
        string s = "Every Round\n";
        s += $"Heal {healAmount}hp";
        return s;
    }
}