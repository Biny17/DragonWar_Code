using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public abstract class RoundUpgrade : Upgrade
{
    public override void ApplyUpgrade(GameObject player)
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public abstract void OnSceneLoaded(Scene scene, LoadSceneMode mode);
}