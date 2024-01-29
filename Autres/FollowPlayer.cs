using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    public Vector3 offset;

    void Start()
    {
        player = Player.instance.transform;     
    }

    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, 0f, player.position.z) + offset;
    }
}
