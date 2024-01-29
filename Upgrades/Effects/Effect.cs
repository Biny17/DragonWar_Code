using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCoroutinePair
{
    public Coroutine Coco;
    public Effect Effect;
    public int nbStack;

    public EffectCoroutinePair(Coroutine coco, Effect effect, int stack)
    {
        Coco = coco;
        Effect = effect;
        nbStack = stack;
    }
}

public abstract class Effect : ScriptableObject
{
    public Particles particle;
    public float duration = 1f;
    public IEnumerator ApplyEffect(Entity stats, int stack = 1)
    {
        stats.gameObject.GetComponentInChildren<ParticleManager>().PlayParticle(particle, duration);
        yield return ApplyEffectImplementation(stats, stack);
    }

    public abstract IEnumerator ApplyEffectImplementation(Entity stats, int stack);
    public abstract string Description();
}
