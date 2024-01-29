using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingArrow : MonoBehaviour
{
    public InputSelection go;
    private GameObject arrow;

    void Start()
    {
        arrow = transform.Find("Image").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (go.inputV == Vector2.zero)
        {
            arrow.SetActive(false);
        } else
        {
            arrow.SetActive(true);
            transform.rotation = Quaternion.Euler(0,0,go.angle);
        }
    }
}
