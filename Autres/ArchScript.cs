using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Autodestoy());
        // StartCoroutine(TpPlayer());
        if (Player.instance.controller != null) Player.instance.controller.enabled = false;
        Player.instance.transform.position = transform.position;
        if (Player.instance.controller != null) Player.instance.controller.enabled = true;
    }
    IEnumerator Autodestoy()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
