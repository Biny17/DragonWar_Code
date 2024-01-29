using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Scripts;
using UnityEngine.SceneManagement;


public class Footsteps: MonoBehaviour
{
    public float footstepsVolume = 0.4f;
    public float frequency = 2f;
    public List<Sound> sounds;
    private Moving entity;
    private float delay;
    private Coroutine coroutine;
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.clip.name = s.name;
            s.source.volume = s.volume * footstepsVolume;
            s.source.pitch = s.pitch;
        }
    }
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        entity = GetComponent<Moving>();
        if (entity == null) Debug.LogError("No Moving component found on " + gameObject.name);
        delay = 1/frequency;

        coroutine = StartCoroutine(FootStepsLoop());

        GameManager.Instance.volumeChange.AddListener(ChangeVolume);
    }

    private void ChangeVolume()
    {
        foreach(Sound s in sounds)
        {
            GameManager gm = GameManager.Instance;
            s.source.volume = s.volume * gm.masterVolume * gm.soundsVolume;
        }        
    }

    private IEnumerator FootStepsLoop()
    {
        while(true)
        {
            yield return new WaitUntil(entity.IsMoving);
            sounds.sample(1)[0].source.Play();
            yield return new WaitForSeconds(delay);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (GameManager.Instance.gameState != GameState.Playing)
        {
            StopCoroutine(coroutine);
        } else {
            coroutine = StartCoroutine(FootStepsLoop());
        }
    }
}
