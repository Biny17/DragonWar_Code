using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Scripts;

[RequireComponent(typeof(AudioSource))]
public class MusicPlaylist : MonoBehaviour
{
    [Range(0f, 1f)]
    public List<AudioClip> playlist;
    private AudioSource audioSource;
    private Coroutine coroutine;
    
    void Start()
    {
        GameManager.Instance.musicPlaylist = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        playlist = playlist.shuffle();
        coroutine = StartCoroutine(PlayMusic());
        ChangeVolume();
        GameManager.Instance.volumeChange.AddListener(ChangeVolume);
    }

    public IEnumerator PlayMusic()
    {
        foreach(AudioClip clip in playlist)
        {
            audioSource.clip = clip;
            audioSource.Play();
            yield return new WaitForSeconds(clip.length);
        }  
    }

    public void PauseMusic()
    {
        if(audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    public void ResumeMusic()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }


    public void StartMusic()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(PlayMusic());
    }

    public void StopMusic()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }
    public void ChangeVolume()
    {
        audioSource.volume = GameManager.Instance.masterVolume * GameManager.Instance.musicVolume * 0.9f;
    }
}
