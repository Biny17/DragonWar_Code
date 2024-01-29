using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public class Player : MonoBehaviour, Moving
{
    [HideInInspector] public CharacterController controller;
    private Entity stats;
    private Vector2 inputV;
    public static Player instance;
    // private Queue<Vector3> positions = new Queue<Vector3>(15);
    private Vector3 direction;
    private Quaternion rotation;
    public GameObject model;
    private bool moving;
    private Animator animator;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        stats = GetComponent<Entity>();
        animator = GetComponentInChildren<Animator>();
        GetComponent<Entity>().onDeath += WhenGameOver;
    }
    void Update()
    {
        direction = new Vector3(inputV.x, 0, inputV.y);
        direction = (direction + new Vector3(Joystick.instance.Horizontal, 0, Joystick.instance.Vertical)).normalized;
        direction = IsoMatrix.ToIsoY * direction;
        moving = direction != Vector3.zero;
        if (moving) rotation = Quaternion.LookRotation(direction);
        model.transform.rotation = rotation;
        animator.SetBool("IsMoving", moving);
        controller.Move(direction * stats.GetSpeed() * Time.deltaTime);
    }
    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.y = 1.04f;
        transform.position = pos;
    }

    private void WhenGameOver()
    {
        GameManager.Instance.LoadMenuScene();
    }

    public Vector3 GetDirection(){
        return direction;
    }
    public bool IsMoving(){
        return moving;
    }
    public Vector3 GetPosition(){
        return transform.position;
    }
    public Quaternion GetRotation(){
        return rotation;
    }
    public Transform GetTransform()
    {
        return transform;
    }
}
 