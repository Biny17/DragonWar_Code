using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Slow", menuName = "Scriptable/Effect/Slow")]
public class Slow : Effect
{
    public int slowPercentage = 10;

    public override IEnumerator ApplyEffectImplementation(Entity entity, int stack = 1)
    {
        entity.speed.percent += -slowPercentage/100f;
        entity.UpdateCachedSpeed();
        yield return new WaitForSeconds(duration);
        entity.speed.percent += slowPercentage/100f;
        entity.UpdateCachedSpeed();

        entity.effects.Remove(GetType());
    }
    public override string Description()
    {
        if(slowPercentage < 100) return $"Slow by {slowPercentage}% for {duration}";
        else return $"Immobilize for {duration}";
    }
}
