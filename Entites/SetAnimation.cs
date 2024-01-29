using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimation : MonoBehaviour
{
    public Anima anima;
    void Start()
    {
        ChangeAnim(anima);
    }
    void ChangeAnim(Anima anima)
    {
        Animator animator = GetComponent<Animator>();
        animator.SetInteger("animation", (int)anima);
    }
}
