using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPosition : MonoBehaviour
{
    public float posX = 100;
    public float posY = 100;

    private RectTransform rectTransform;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        GameManager.Instance.gameStateChange += LeftOrRight;
        LeftOrRight(GameManager.Instance.gameState);
    }

    void LeftOrRight(GameState gs)
    {
        if (GameManager.Instance.joystickSide == GameManager.JoystickSide.Left)
        {
            Debug.Log("Left");
            rectTransform.anchorMin = new Vector2(0f, 0f);
            rectTransform.anchorMax = new Vector2(0f, 0f);
            rectTransform.anchoredPosition = new Vector2(-posX, posY);
        }
        if (GameManager.Instance.joystickSide == GameManager.JoystickSide.Right)
        {
            Debug.Log("Right");
            rectTransform.anchorMin = new Vector2(1f, 0f);
            rectTransform.anchorMax = new Vector2(1f, 0f);
            rectTransform.anchoredPosition = new Vector2(posX, posY);
        }
    }
    void OnDestroy()
    {
        GameManager.Instance.gameStateChange -= LeftOrRight;
    }
}
