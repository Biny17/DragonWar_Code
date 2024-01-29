using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;


public partial class EnemyManager : MonoBehaviour
{
    public List<EnemyCard> enemyCards;

    public List<GameObject> GeneratePool(int lvl)
    {
        List<EnemyCard> choosed = Diversity(lvl);
        int maxDens = EnemyDensityMax(lvl);
        int dens = 0;
        List<GameObject> pool = new List<GameObject>();

        while (dens < maxDens)
        {
            EnemyCard card = choosed.sample(1)[0];
            dens += card.density;
            pool.Add(card.GetGameObject(lvl));
        }
        return pool;
    }

    public int EnemyDensityMax(int lvl)
    {
        int nb = (int)(24/(1+Mathf.Exp(-lvl/2 + 4)));
        nb += 6;
        return nb;
    }

    public List<EnemyCard> Diversity(int lvl)
    {
        if (lvl < 6)
        {
            return enemyCards.choice(1);
        }
        if (lvl < 12)
        {
            return enemyCards.choice(2);
        }
        if (lvl < 18)
        {
            if (Random.value < 0.7) return enemyCards.choice(2);
            else return enemyCards.choice(3);
        }
        return enemyCards.choice(3);
    }
}