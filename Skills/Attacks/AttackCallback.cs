using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCallback : MonoBehaviour
{

    public delegate void HitEvent(Collider other);
    public event HitEvent OnHit;
    private void OnTriggerEnter(Collider other)
    {
        OnHit?.Invoke(other);
    }
}
