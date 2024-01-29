using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePicker : MonoBehaviour
{
    public List<UpgradeUI> tiles;
    public InputSelection playerInput;
    public float FillTime;
    private int current = 0;
    private float fill;


    private int AngleToIndex()
    {
        if ( 0 <= playerInput.angle && playerInput.angle < 90) return 1;
        else if (90 <= playerInput.angle && playerInput.angle <= 180) return 0;
        else if (-180 <= playerInput.angle && playerInput.angle < -90) return 2;
        else if (-90 <= playerInput.angle && playerInput.angle < 0) return 3;
        else return -1;
    }


    void Update() 
    {
        if (playerInput.inputV != Vector2.zero)
        {
            if (AngleToIndex() != current) 
            {
                tiles[current].ChangeFill(0f);
                current = AngleToIndex();
                fill = 0;
            } else
            {
                fill += Time.deltaTime/FillTime;
                tiles[current].ChangeFill(fill);
            }
        }
    }
}
