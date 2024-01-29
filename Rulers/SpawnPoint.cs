using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public EnemyManager spawner;
    void Start()
    {
        if (spawner == null)
        {
            spawner = FindObjectOfType<EnemyManager>();
        }
        spawner.AddSpawnPoints(this);
    }

    public Vector3 GetVector3()
    {
        return transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, 0.6f);
    }
}
