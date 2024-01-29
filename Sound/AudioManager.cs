using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.clip.name = s.name;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    void Start()
    {
        if(transform.parent == null)
        {
            DontDestroyOnLoad(this);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
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

    public void Play(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.clip.name == name);
        s?.source.Play();
    }

    public bool DoesExist(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.clip.name == name);
        return s != null;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Invoke(nameof(AutoDestruct), 4f);
    }

    private void AutoDestruct()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Destroy(gameObject);
    }
}
