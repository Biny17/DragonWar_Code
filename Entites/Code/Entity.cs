using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public delegate void OnDeath();
public class Entity : MonoBehaviour
{
    public StatObject baseStats;
    [HideInInspector] public FlatPercent damageOutput = new();
    [HideInInspector] public FlatPercent damageTaken = new();
    [HideInInspector] public int maxHealth;
    [HideInInspector] public int Health;
    [HideInInspector] public FlatPercent speed = new();
    public event Action<int, int> HealthChanged;
    public event Action<int> MaxHealthChanged;
    public event Action<float> SpeedChanged;
    [HideInInspector] public Dictionary<Type, EffectCoroutinePair> effects = new();
    private float cachedSpeed = float.NaN;
    public GameObject PopTextPrefab;
    public event OnDeath onDeath;
    
    public void Awake()
    {
        maxHealth = baseStats.MaxHealth;
        Health = maxHealth;
        UpdateHealth(maxHealth);
        UpdateCachedSpeed();
    }
    public bool UpdateHealth(int amount)
    {
        Health += amount;
        Health = Mathf.Clamp(Health, 0, maxHealth);
        HealthChanged?.Invoke(Health, amount);
        if (Health <= 0)
        {
            onDeath?.Invoke();
            Destroy(gameObject);
            return false;
        }
        return true;
    }
    public bool TakeDamage(int amount)
    {
        amount = (int)(amount * damageTaken.percent + damageTaken.flat + 0.5f);
        return UpdateHealth(-amount);
    }
    public void Heal(int amount)
    {
        UpdateHealth(amount);
    }
    public void AddMaxHealth(int flat)
    {
        Health += flat;
        maxHealth += flat;

        HealthChanged?.Invoke(Health, flat);
        MaxHealthChanged?.Invoke(maxHealth);
    }
    public void UpdateCachedSpeed()
    {
        cachedSpeed = baseStats.speed * speed.percent + speed.flat;
        SpeedChanged?.Invoke(cachedSpeed);
    }
    public void AddSpeedFlat(float flat)
    {
        speed.flat += flat;
        UpdateCachedSpeed();
    }

    public float GetSpeed()
    {
        return cachedSpeed;
    }
    void ShowDamageText(int amount)
    {
        var go = Instantiate(PopTextPrefab, transform.position + UnityEngine.Random.insideUnitSphere/4, IsoMatrix.ToIso);
        go.GetComponent<TextMesh>().text = amount.ToString();
    }
    public void AddEffect(Effect newEffect, OnKill onKill)
    {
        if (effects.ContainsKey(newEffect.GetType()))
        {
            EffectCoroutinePair ecp = effects[newEffect.GetType()];
            StopCoroutine(ecp.Coco);
            ecp.nbStack++;
            Coroutine coroutine = StartCoroutine(newEffect.ApplyEffect(this, stack:ecp.nbStack));    
            ecp.Coco = coroutine;
        }
        else
        {
            Coroutine coroutine = StartCoroutine(newEffect.ApplyEffect(this));
            EffectCoroutinePair ecp = new(coroutine, newEffect, 1);
            effects[newEffect.GetType()] = ecp;
        }
    }
}
