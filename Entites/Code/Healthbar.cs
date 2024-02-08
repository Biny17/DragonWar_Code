using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private int markerFrequency = 50; 
    public Degrade gradiento;
    private Entity stats;
    private Image fill;

    private void Start()
    {
        stats = GetComponentInParent<Entity>();
        fill = transform.Find("Fill").GetComponent<Image>();

        stats.HealthChanged += UpdateFill;
        stats.MaxHealthChanged += UpdateSprite;


        fill.sprite = CreateHealthBarSprite();
        fill.type = Image.Type.Filled;
        fill.fillMethod = Image.FillMethod.Horizontal;
        
        UpdateFill(stats.Health, 0);
    }
    private void UpdateFill(int newHealth, int dummy)
    {
        float fillPercentage = Mathf.InverseLerp(0, stats.maxHealth, newHealth);
        fill.fillAmount = fillPercentage;
        fill.color = gradiento.gradient.Evaluate(fillPercentage);
    }
    void Update()
    {
        transform.rotation = IsoMatrix.ToIso;
    }

    void UpdateSprite(int n)
    {
        fill.sprite = CreateHealthBarSprite();
    }

    private Sprite CreateHealthBarSprite()
    {
    
        int textureWidth = 512;
        int textureHeight = 64;
        Texture2D texture = new Texture2D(textureWidth, textureHeight);
        
        for (int x = 0; x < textureWidth; x++)
        {
            for (int y = 0; y < textureHeight; y++)
            {
                float nextMarkerX = textureWidth / ((float)stats.maxHealth / markerFrequency);
                Color color = (x+1) % nextMarkerX < 15 ? Color.black : Color.white;
                color = x < nextMarkerX/2 ? Color.white : color;
                texture.SetPixel(x, y, color);
            }
        }
        texture.filterMode = FilterMode.Bilinear;
        // disable mipmaps
        texture.mipMapBias = 0;
        texture.Apply();
        Rect rect = new Rect(0, 0, textureWidth, textureHeight);
        Sprite sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
        return sprite;
    }
}
