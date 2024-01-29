using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectionBackground : MonoBehaviour
{
    private Image background;
    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Image>();
        background.sprite = CreateHealthBarSprite();
        background.color = new Color(1f,1f,1f,1f);
    }

    private Sprite CreateHealthBarSprite()
    {

        int width = 1080;
        int height = 1080;
        Texture2D texture = new Texture2D(width, height);
        
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = Mathf.Abs(x-width/2) <= 3 ? Color.black: new Color(1f,1f,1f,0f); 
                color = Mathf.Abs(y-height/2) <= 2 ? Color.black: color; 
                texture.SetPixel(x, y, color);
            }
        }
        texture.filterMode = FilterMode.Point;
        texture.Apply();
        Rect rect = new Rect(0, 0, width, height);
        Sprite sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
        return sprite;
    }
}
