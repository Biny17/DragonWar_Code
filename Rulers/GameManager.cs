using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public enum GameState
{
    Menu,
    Pause,
    PowerupSelection,
    Playing
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public GameState gameState;
    [HideInInspector] public MusicPlaylist musicPlaylist;
    public delegate void GameStateChange(GameState newState);
    public GameStateChange gameStateChange;
    [HideInInspector] public float masterVolume;
    [HideInInspector] public float musicVolume;
    [HideInInspector] public float soundsVolume;
    public enum JoystickSide {Right, Left}
    [HideInInspector] public JoystickSide joystickSide = JoystickSide.Right;
    public GameState beforePause;
    public UnityEvent volumeChange;



    public int lvl = 1;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
        gameStateChange += (newState) => gameState = newState;
        gameStateChange += (newState) => 
            beforePause = (newState == GameState.Pause) ? beforePause : newState;

        masterVolume = 1f;
        musicVolume = 1f;
        soundsVolume = 1f;
    }
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            lvl = 0;
            gameStateChange.Invoke(GameState.Menu);
        }
    }

    public void LoadMenuScene()
    {
        gameStateChange.Invoke(GameState.Menu);
        SceneManager.LoadScene("Menu");
    }

    public void LoadLevelScene()
    {
        gameStateChange.Invoke(GameState.Playing);
        lvl++;
        int i = Random.Range(0,2);
        if (i==0) SceneManager.LoadScene("SceneMap1");
        else if (i==1) SceneManager.LoadScene("SceneMap2");
        else Debug.Log("random scene index out of range");
    }

    public void LoadPause()
    {
        gameStateChange.Invoke(GameState.Pause);
        Time.timeScale = 0f;
        PauseMenu.Instance.ShowMenu();
        if(musicPlaylist != null)
            musicPlaylist.PauseMusic();
    }
    public void LeavePause()
    {
        gameStateChange.Invoke(beforePause);
        Time.timeScale = 1f;
        PauseMenu.Instance.HideMenu();
        if(musicPlaylist != null)
            musicPlaylist.ResumeMusic();
    }

    public void LoadUpgradeScene()
    {
        gameStateChange.Invoke(GameState.PowerupSelection);
        SceneManager.LoadScene("PowerupSelection");
    }

    public void ChangeMasterVolume(float newVolume)
    {
        masterVolume = newVolume;
        volumeChange.Invoke();
    }
    public void ChangeMusicVolume(float newVolume)
    {
        musicVolume = newVolume;
        volumeChange.Invoke();
    }
    public void ChangeSoundsVolume(float newVolume)
    {
        soundsVolume = newVolume;
        volumeChange.Invoke();
    }

    public void RightJoystickSide(bool IsRight)
    {
        JoystickSide side;
        
        if(IsRight)
            side = JoystickSide.Right;
        else
            side = JoystickSide.Left;

        joystickSide = side;
    }
    public IEnumerator DebugState()
    {
        while(true)
        {
            Debug.Log(gameState.ToString());
            Debug.Log(beforePause.ToString());
            yield return new WaitForSecondsRealtime(1f);
        }
    }
}
