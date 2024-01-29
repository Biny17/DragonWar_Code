using UnityEngine;

public class FlatPercent
{
    public float flat = 0f;
    public float percent = 1f;

    public int Output(int dmgIn)
    {
        return (int)(dmgIn*percent+flat);
    }
}