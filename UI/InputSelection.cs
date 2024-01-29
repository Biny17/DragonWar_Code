using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSelection : MonoBehaviour
{
    [HideInInspector] public Vector2 inputV;
    [HideInInspector] public float angle;
    
    // private void OnMovement(InputValue value)
    // {
    //     inputV = value.Get<Vector2>().normalized;
    //     angle = Mathf.Atan2(inputV.y, inputV.x) * Mathf.Rad2Deg;
    // }
    void Update()
    {
        inputV = Joystick.instance.Direction;
        inputV.Normalize();
        angle = Mathf.Atan2(inputV.y, inputV.x) * Mathf.Rad2Deg;
    }
}
