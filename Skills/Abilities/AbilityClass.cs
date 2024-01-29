using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum abilities
{
    Circle,
    Slash
}

public abstract partial class AbilityClass : MonoBehaviour
{
    public FlatPercent playerDamageOutput;
    public FlatPercent damageOutput = new FlatPercent();
    public int Dmg;
    public float CdBase = 2f;
    [HideInInspector] public int CdReduction;
    public bool StopCast = false;
    public List<AbilityUpgrade> Upgrades = new List<AbilityUpgrade>();
    public List<Effect> effects = new List<Effect>();



    protected virtual void Start()
    {
        audioManager = GetComponent<AudioManager>();
        owner = HighestParent().GetComponent<Entity>();
        playerDamageOutput = owner.damageOutput;
        foreach (AbilityUpgrade upgrade in Upgrades)
        {
            upgrade.UpgradeAbility(this);
        }
        if(audioManager != null) castInstant += () => audioManager.Play("audioCast");
        castCoroutines.Add(InstantCasts);
        castCoroutines.Add(Cast);
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (SceneManager.GetActiveScene().name != "PowerupSelection") 
            loopCoroutine = StartCoroutine(Loop());
            
    }

    
    public IEnumerator Loop()
    {
        while(true)
        {
            yield return new WaitForSeconds(GetCd());

            if (StopCast==true) yield return new WaitWhile(Player.instance.IsMoving);
            StartCoroutine(playCoroutines());
            // StartCoroutine(Cast());
        }
    }

    public IEnumerator playCoroutines()
    {
        foreach(CastAction action in castCoroutines) 
        {
            yield return action();
        }
    }


    public float GetCd()
    {
        return CdBase*100/(100+CdReduction);
    }

    public int GetDmg(int damage)
    {
        return playerDamageOutput.Output(damageOutput.Output(damage));
    }

    public void Apply(Entity target)
    {
        audioManager?.Play("audioHit");
        if (!target.TakeDamage(GetDmg(Dmg)))
        {
            onKill?.Invoke(this);
        } else
        {
            foreach (Effect e in effects) 
            {
                target.AddEffect(e, onKill);
            }
        }
    }
  
    public abstract IEnumerator Cast();

    public GameObject HighestParent()
    {
        Transform currentParent = transform;

        while (currentParent.parent != null)
        {
            currentParent = currentParent.parent;
        }

        return currentParent.gameObject;
    }
}
