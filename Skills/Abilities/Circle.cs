using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Circle : AbilityClass
{
    public float ReScale;
    public float Radius;
    private ParticleSystem particle;
    
    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        
        AdjustScale();
    }
    private void AdjustScale()
    {
        transform.localScale = new Vector3(Radius * ReScale, Radius * ReScale, Radius * ReScale);
    }

    public override IEnumerator Cast()
    {
        particle.Play();
        yield return new WaitForSeconds(0.15f);
        Collider[] colliders = Physics.OverlapSphere(transform.position, Radius);
        foreach (Collider hit in colliders)
        {
            if (hit.CompareTag("Enemy"))
            {
                Entity enemyStat = hit.gameObject.GetComponent<Entity>();
                Apply(enemyStat);
            }
        }
        yield return null;
    }
    // on draw gizzmo
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}