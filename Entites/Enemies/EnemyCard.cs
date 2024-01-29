using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;


public abstract class EnemyCard : ScriptableObject
{
    public GameObject go;
    public int density;
    public StatObject SoStats;

    
    public int GetValuesScaling(Dictionary<int,int> keyValuePairs, int lvl)
    {
        int v = 0;

        foreach (var kvp in keyValuePairs)
        {
            if (lvl >= kvp.Key)
            {
                v += kvp.Value;
            }
        }
        return v;
    }
    public float GetValuesScaling(Dictionary<int,float> keyValuePairs, int lvl)
    {
        float v = 0;

        foreach (var kvp in keyValuePairs)
        {
            if (lvl >= kvp.Key)
            {
                v += kvp.Value;
            }
        }
        return v;
    }

    public abstract GameObject GetGameObject(int lvl);
}