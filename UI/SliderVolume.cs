using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events; 

public class SliderVolume : MonoBehaviour
{
    private Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();

        UnityAction<float> action = GameManager.Instance.ChangeMasterVolume;

        if (gameObject.name == "MasterVolumeSlider")
            action = GameManager.Instance.ChangeMasterVolume;
        else if (gameObject.name == "MusicVolumeSlider")
            action = GameManager.Instance.ChangeMusicVolume;
        else if (gameObject.name == "SoundsVolumeSlider")
            action = GameManager.Instance.ChangeSoundsVolume;
        else
            Debug.LogError("SliderVolume.cs: Slider name not recognized");

        slider.onValueChanged.AddListener(action);
    }
}
