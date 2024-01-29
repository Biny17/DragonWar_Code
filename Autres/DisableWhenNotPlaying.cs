using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisableWhenNotPlaying : MonoBehaviour
{
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (GameManager.Instance.gameState != GameState.Playing)
        {
            gameObject.SetActive(false);
        } else {
            gameObject.SetActive(true);
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (GameManager.Instance.gameState != GameState.Playing)
        {
            gameObject.SetActive(false);
        } else {
            gameObject.SetActive(true);
        }
    }
}
