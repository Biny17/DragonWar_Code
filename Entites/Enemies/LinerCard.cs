using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LinerCard", menuName = "Scriptable/EnemyCard/LinerCard")]
public class LinerCard : EnemyCard
{
    private Dictionary<int,int> damageScaling = new Dictionary<int, int>
    {
        {0,30},
        {15,10}
    };
    private Dictionary<int,int> healthScaling = new Dictionary<int, int>
    {
        {0,90},
        {2,20},
        {4,20},
        {6,20},
        {8,10},
        {10,30},
        {12,30},
        {14,30},
        {16,40},
        {18,30},
        {20,40},
    };
    private Dictionary<int,float> speedScaling = new Dictionary<int, float>
    {
        {0,2.5f},
        {10,0.5f},
        {20,0.5f}
    };


    public override GameObject GetGameObject(int lvl)
    {
        SoStats.speed = GetValuesScaling(speedScaling, lvl);
        SoStats.MaxHealth = GetValuesScaling(healthScaling, lvl);

        go.GetComponentInChildren<CastAttack>()
        .ChangeDamage(GetValuesScaling(damageScaling, lvl));
        go.GetComponentInChildren<AttackMob>()
        .ChangeDamage(GetValuesScaling(damageScaling, lvl));

        return go;
    }
}