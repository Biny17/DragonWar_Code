using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnKill(AbilityClass ability);

public abstract partial class AbilityClass : MonoBehaviour
{
    private AudioManager audioManager;
    public OnKill onKill;

    [HideInInspector] public Entity owner;
    public delegate IEnumerator CastAction();
    private List<CastAction> castCoroutines = new();
    private Coroutine loopCoroutine;

    public delegate void CastInstant();
    private CastInstant castInstant;

    private IEnumerator InstantCasts()
    {
        castInstant?.Invoke();
        return null;
    }
    
    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        try
        {
            StopCoroutine(loopCoroutine);
        }
        catch (Exception ex)
        {
            DoesNothing(ex);
        }

        if (GameManager.Instance.gameState == GameState.Playing
        && this != null && gameObject != null)
        {
            loopCoroutine = StartCoroutine(Loop());
        }
    }
    void DoesNothing(Exception exception)
    {

    }
}