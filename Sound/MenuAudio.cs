using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    private AudioManager audioManager;

    void Start()
    {
        audioManager = GetComponent<AudioManager>();
        StartCoroutine(WaitForPlay());
    }

    private IEnumerator WaitForPlay()
    {
        yield return new WaitWhile(() => GameManager.Instance.gameState != GameState.Playing);
        audioManager.Play("Play");
    }
}
