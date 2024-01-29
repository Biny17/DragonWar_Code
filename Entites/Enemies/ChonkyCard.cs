using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChonkyCard", menuName = "Scriptable/EnemyCard/ChonkyCard")]
public class ChonkyCard : EnemyCard
{
    private Dictionary<int,int> damageScaling = new Dictionary<int, int>
    {
        {0,30},
        {15,10}
    };
    private Dictionary<int,int> healthScaling = new Dictionary<int, int>
    {
        {0,100},
        {2,30},
        {4,30},
        {6,40},
        {8,50},
        {10,60},
        {12,50},
        {14,60},
        {16,50},
        {18,60},
        {20,60},
    };
    private Dictionary<int,float> speedScaling = new Dictionary<int, float>
    {
        {0,2.35f},
        {10,0.2f},
        {20,0.15f}
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