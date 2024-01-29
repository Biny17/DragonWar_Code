using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Poison", menuName = "Scriptable/Effect/Poison")]
public class Poison : Effect
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
            entity.TakeDamage(ticDamage*stack + 1);
            total += ticDamage;
            yield return new WaitForSeconds(ticInterval);
        }
        entity.effects.Remove(GetType());
    }
    public override string Description()
    {
        string s = $"Deal {totalDamage}\nover {duration} seconds\nStackable";
        return s;
    }

}