using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpgradeFill : MonoBehaviour
{
    private Image Filler;
    void Start()
    {
        Filler = GetComponent<Image>();
        Filler.sprite = CreateFill();
        Filler.type = Image.Type.Filled;
        Filler.fillMethod = Image.FillMethod.Vertical;
        Filler.fillAmount = 0f;
    }

    public void UpdateFill(float amount)
    {
        // clamp amount
        amount = Mathf.Clamp(amount, 0f, 1f);
        Filler.fillAmount = amount;
    }

    private Sprite CreateFill()
    {
    
        int textureWidth = 500;
        int textureHeight = 1000;
        Texture2D texture = new Texture2D(textureWidth, textureHeight);
        
        for (int x = 0; x < textureWidth; x++)
        {
            for (int y = 0; y < textureHeight; y++)
            {
                texture.SetPixel(x, y, Color.white);
            }
        }
        texture.Apply();
        Rect rect = new Rect(0, 0, textureWidth, textureHeight);
        Sprite sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
        return sprite;
    }
}
