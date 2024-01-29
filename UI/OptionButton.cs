using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour
{
    private Button _button;
    public static OptionButton Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        GameManager gm = GameManager.Instance;
        if (gm.gameState != GameState.Pause)
        {
            gm.LoadPause();
        }
        else 
        {
            gm.LeavePause();
        }
    }

}
