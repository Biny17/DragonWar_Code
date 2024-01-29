using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileAbility data;
    private int penetration;

    private void Start()
    {
        // check if data is null
        if (data == null)
        {
            Debug.LogError("Projectile data is null");
        }
        penetration = data.penetration;
        Invoke("DestroyItself", data.projRange/data.projSpeed);
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * data.projSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Entity enemyStat = other.GetComponent<Entity>();

            data.Apply(enemyStat);
            penetration--;
            if (penetration==0) DestroyItself();
        }
    }

    private void DestroyItself()
    {
        Destroy(gameObject);
    }
}
