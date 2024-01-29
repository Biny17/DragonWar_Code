using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Particles
{
    ChainedFire,
    ChainedFrost,
    TorchYellow,
    BubblesRisingSlime
}

public class ParticleManager : MonoBehaviour
{
    public ParticleSystem chainedFire;
    public ParticleSystem chainedFrost;
    public ParticleSystem torchYellow;
    public ParticleSystem bubblesRisingSlime;

    public Dictionary<Particles, ParticleSystem> valuePairs = new();
    public Dictionary<Particles, Coroutine> coroutines = new();

    void Start()
    {
        chainedFire.Stop();
        chainedFrost.Stop();
        torchYellow.Stop();
        bubblesRisingSlime.Stop();
        valuePairs.Add(Particles.ChainedFire, chainedFire);
        valuePairs.Add(Particles.ChainedFrost, chainedFrost);
        valuePairs.Add(Particles.TorchYellow, torchYellow);
        valuePairs.Add(Particles.BubblesRisingSlime, bubblesRisingSlime);
    }

    public void PlayParticle(Particles particles, float duration)
    {
        if (coroutines.ContainsKey(particles))
            StopCoroutine(coroutines[particles]);
        coroutines[particles] = StartCoroutine(PlayCoroutine(particles, duration));
    }
    private IEnumerator PlayCoroutine(Particles particles, float duration)
    {
        valuePairs[particles].Play();
        yield return new WaitForSeconds(duration);
        valuePairs[particles].Stop();
        valuePairs[particles].Clear();
    }

    void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}
