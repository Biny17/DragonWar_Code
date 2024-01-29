using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkVolume : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameManager.Instance.volumeChange.AddListener(ChangeVolume);
        ChangeVolume();
    }

    void ChangeVolume()
    {
        audioSource.volume = GameManager.Instance.masterVolume * GameManager.Instance.soundsVolume;
    }
}
