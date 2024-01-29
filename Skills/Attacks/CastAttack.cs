using UnityEngine;

public class CastAttack : MonoBehaviour
{
    public GameObject attackPrefab;
    public int damage = 40;
    private GameObject attackInstance;

    void Start()
    {
        attackInstance = Instantiate(attackPrefab, transform);
        AttackCallback ac = attackInstance.GetComponentInChildren<AttackCallback>();
        ac.OnHit += Touched;
    }

    public void Cast()
    {
        attackInstance.GetComponent<ICast>().Cast();
    }

    public void Touched(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Entity>().TakeDamage(damage);
        }
    }

    public void ChangeDamage(int newDamage)
    {
        damage = newDamage;
    }
}
