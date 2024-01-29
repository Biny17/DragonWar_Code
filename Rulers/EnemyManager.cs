using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Scripts;


public partial class EnemyManager : MonoBehaviour
{
    public float spawnTime = 0.5f;
    public LayerMask layerMask;
    private List<GameObject> instanciated = new List<GameObject>();
    public List<SpawnPoint> spawnPoints = new();

    void Start()
    {
        StartCoroutine(Spawn(delay: 1.2f));
    }

    public void AddSpawnPoints(SpawnPoint spawnPoint)
    {
        spawnPoints.Add(spawnPoint);
    }

    public IEnumerator Spawn(float delay)
    {
        yield return new WaitForSeconds(2f);
        foreach (GameObject enemy in GeneratePool(GameManager.Instance.lvl))
        {
            for (int i = 0; i < 20; i++)
            {
                Vector3 spawnPosition = spawnPoints.sample()[0].GetVector3();
                if (!Physics.CheckSphere(spawnPosition, 0.6f, layerMask))
                {
                    instanciated.Add(Instantiate(enemy, spawnPosition, Quaternion.identity));
                    break;
                }
            }
            yield return new WaitForSeconds(delay);
        }
        StartCoroutine(CheckLeft());
    }
    public IEnumerator CheckLeft()
    {
        while(!IsClear())
        {
            yield return new WaitForSeconds(1f);
        }
        GameManager.Instance.LoadUpgradeScene();
    }
    public bool IsClear()
    {
        instanciated.RemoveAll(item => item == null);
        
        if(instanciated.Count == 0)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
