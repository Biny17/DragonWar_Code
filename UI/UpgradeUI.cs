using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [HideInInspector]
    public TextMeshProUGUI text;
    [HideInInspector]
    public float Filling;
    private UpgradeFill upgradeFill;
    private Image icon;

    void Awake()
    {
        text = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        icon = transform.Find("Icon").GetComponent<Image>();
        upgradeFill = GetComponentInChildren<UpgradeFill>();
        Filling = 0f;
    }

    public void ChangeFill(float a)
    {
        a = Mathf.Clamp(a, 0f, 1f);        
        Filling = a;
        upgradeFill.UpdateFill(a);
    }

    public void ChangeText(string s)
    {
        if (text == null) text = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        
        text.text = s;
    }
    public void ChangeImg(Sprite s)
    {
        icon.sprite = s;
    }
}
