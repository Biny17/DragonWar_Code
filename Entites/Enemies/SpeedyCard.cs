using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedyCard", menuName = "Scriptable/EnemyCard/SpeedyCard")]
public class SpeedyCard : EnemyCard
{
    private Dictionary<int,int> damageScaling = new Dictionary<int, int>
    {
        {0,25},
    };
    private Dictionary<int,int> healthScaling = new Dictionary<int, int>
    {
        {0,50},
        {2,10},
        {4,10},
        {6,20},
        {8,20},
        {10,40},
        {12,20},
        {14,10},
        {16,10},
        {18,40},
        {20,50},
    };
    private Dictionary<int,float> speedScaling = new Dictionary<int, float>
    {
        {0,6f},
        {10,1f},
        {20,2f},
        {30,5f}
    };


    public override GameObject GetGameObject(int lvl)
    {
        SoStats.speed = GetValuesScaling(speedScaling, lvl);
        SoStats.MaxHealth = GetValuesScaling(healthScaling, lvl);
        
        go.GetComponentInChildren<AttackMob>()
        .ChangeDamage(GetValuesScaling(damageScaling, lvl));

        return go;
    }
}