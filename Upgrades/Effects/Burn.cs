using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Burn", menuName = "Scriptable/Effect/Burn")]
public class Burn : Effect
{
    public int frequence = 2;
    public int totalDamage;


    public override IEnumerator ApplyEffectImplementation(Entity entity, int stack = 1)
    {
        int ticNb = (int)(frequence*duration);
        int ticDamage = totalDamage/ticNb;
        float ticInterval = 1f/frequence;
        int total = 0;
        
        for(int i = 0; i < ticNb; i++)
        {
            entity.TakeDamage(ticDamage);
            total += ticDamage;
            yield return new WaitForSeconds(ticInterval);
        }
        entity.TakeDamage(totalDamage - total);
        entity.effects.Remove(GetType());
    }

    public override string Description()
    {
        string s = $"Deal {totalDamage} over {duration} seconds";
        return s;
    }
}