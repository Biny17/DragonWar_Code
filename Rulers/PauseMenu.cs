using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void ShowMenu()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
    public void HideMenu()
    {
        foreach(Transform child in transform)
        {
            OptionButton optionButtonScript = child.GetComponent<OptionButton>();

            if (optionButtonScript == null)
                child.gameObject.SetActive(false);
        }
    }
}
