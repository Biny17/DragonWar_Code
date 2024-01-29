using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class VisualDamageHeal : MonoBehaviour
{
    public static PopText textPrefab;
    private static ObjectPool<PopText> pool;
    public int damageThreshold;
    private Entity entity;

    void Start()
    {
        entity = GetComponent<Entity>();
        entity.HealthChanged += HealthChange;
        if (textPrefab == null)
            textPrefab = Resources.Load<PopText>("FloatingText");
    }
    static VisualDamageHeal()
    {
        pool = new ObjectPool<PopText>(
            createFunc: CreateText,
            actionOnGet:  null,
            actionOnRelease: null,
            defaultCapacity: 150
        );
    }

    private static PopText CreateText()
    {
        PopText go = Instantiate(textPrefab);
        return go;
    }

    void HealthChange(int newHealth, int diff)
    {
        if(diff < 0)
        {
            DamagePopup(-diff);
        } else {
            HealAura(diff);
        }
    }

    void DamagePopup(int amount)
    {
        if(amount >= damageThreshold){
            PopText popText = pool.Get();
            popText.gameObject.SetActive(true);
            popText.Init(transform.position, pool, amount.ToString());
        }
    }

    void HealAura(int amount)
    {

    }
}
