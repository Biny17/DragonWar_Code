using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAbility : AbilityClass
{
    public GameObject proj;
    public float projSpeed = 1f;
    public float projRange = 2f;
    public int penetration = 1;

    public GameObject CreateProjectile(Quaternion rotation)
    {
        GameObject projInstance = Instantiate(proj, transform.position, rotation);
        
        Projectile projectileScript = projInstance.GetComponent<Projectile>();
        projectileScript.data = this;
        return projInstance;
    }
    public override IEnumerator Cast()
    {
        CreateProjectile(Player.instance.GetRotation());
        yield return null;
    }
}