using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;
using UnityEngine.UI;

public class TileSelection : MonoBehaviour
{
    public List<GameObject> tiles;
    public InputSelection inputSelection;
    public float lockTime = 2f;
    private int current;
    private float lockFill;
    private UpgradeManager upgradeManager;
    public AudioManager audioManager;
    public List<string> selectionSounds;

    void Start()
    {
        upgradeManager = GetComponent<UpgradeManager>();
        audioManager.Play("Start");
        foreach (string s in selectionSounds)
        {
            if(!audioManager.DoesExist(s))
            {
                Debug.LogError("SelectionSound " + s + " not found in AudioManager");
            }
        }
    }
    private int AngleToIndex()
    {
        float angle = inputSelection.angle;
        angle = angle < 0 ? angle+360: angle;
        if(0 <= angle && angle < 90) return 1;
        else if (90 <= angle && angle < 180) return 0;
        else if (180 <= angle && angle < 270) return 2;
        else if (270 <= angle && angle < 360) return 3;
        else return -1;
    }

    private void NewSelectionSound()
    {
        if (selectionSounds.Count > 0)
            audioManager.Play(selectionSounds.pickOne());
    }

    void Update()
    {
        if(inputSelection.inputV != Vector2.zero)
        {
            if(AngleToIndex() == current)
            {
                lockFill += Time.deltaTime / lockTime;
                if (lockFill >= 1) 
                {
                    audioManager.Play("Selected");
                    upgradeManager.SelectUpgrade(current);
                    enabled = false;
                }
                SetTileFill(current, lockFill);
            } else 
            {
                lockFill = 0f;
                SetTileFill(current, lockFill);
                current = AngleToIndex();
                NewSelectionSound();
            }
        } else
        {
            lockFill = 0f;
            SetTileFill(current, lockFill);
        }
    }


    private void SetTileFill(int index, float fill)
    {
        UpgradeUI upgradeUI = tiles[index].GetComponent<UpgradeUI>();
        upgradeUI.ChangeFill(fill);
    }


}
