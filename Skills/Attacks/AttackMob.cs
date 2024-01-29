using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackMob : MonoBehaviour
{
    private Collider col;
    private AttackCallback ac;
    public float attackCoolDown = 4f;
    public int damage = 40;


    void Start()
    {
        col = transform.Find("Hitbox").GetComponent<Collider>();
        col.isTrigger = true;
        ac = GetComponentInChildren<AttackCallback>();
        ac.OnHit += OnTouched;
    }

    void OnTouched(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Entity>().TakeDamage(damage);
            StartCoroutine(Disabling());
        }
    }

    IEnumerator Disabling()
    {
        col.enabled = false;
        yield return new WaitForSeconds(attackCoolDown);
        col.enabled = true;
    }
    public void Cast()
    {
        Debug.Log("this enemy doesn't cast and deal damage on contact");
    }

    public void ChangeDamage(int newDamage)
    {
        damage = newDamage;
    }
}
