using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLiner : MonoBehaviour, ICast
{
    private ParticleSystem ps;
    private GameObject line;
    public float indicatorTime = 0.6f;
    private Collider col;

    void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        line = transform.Find("Line").gameObject;
        line.SetActive(false);
        col = GetComponentInChildren<Collider>();
        col.isTrigger = true;
        col.enabled = false;
    }
    public void Cast()
    {
        StartCoroutine(Attacking());
    }
    IEnumerator Attacking()
    {
        line.SetActive(true);
        yield return new WaitForSeconds(indicatorTime);
        line.SetActive(false);
        ps.Play();
        col.enabled = true;
        yield return new WaitForSeconds(0.10f);
        col.enabled = false;
    }
}
