using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnim : MonoBehaviour
{
    public GameObject spawnOnDeath;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Entity>().onDeath += AnimationOnDeath;
    }

    void AnimationOnDeath()
    {
        Instantiate(spawnOnDeath, transform.position, Quaternion.identity);
    }
}
