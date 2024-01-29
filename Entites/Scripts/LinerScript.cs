using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class LinerScript : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    public float attackCoolDown = 2f;
    public float attackDistance = 6f;
    private CastAttack linerAttack;
    private bool lockRotation;
    private Entity stats;

    void Start()
    {
        stats = GetComponent<Entity>();
        animator = GetComponent<Animator>();
        animator.SetInteger("animation", 17);
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.speed = stats.GetSpeed();
        stats.SpeedChanged += ChangeSpeed;
        linerAttack = GetComponent<CastAttack>();
        StartCoroutine(MayAttack());
    }
    void ChangeSpeed(float newSpeed)
    {
        agent.speed = newSpeed;
    }
    IEnumerator MayAttack()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            if (DistanceToPlayer() < attackDistance)
            {
                yield return StartCoroutine(Attack());
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator Attack()
    {
        linerAttack.Cast();
        agent.isStopped = true;
        lockRotation = true;
        ChangeAnim(Anima.Roar);
        yield return new WaitForSeconds(1.1f);
        ChangeAnim(Anima.Fly);
        yield return new WaitForSeconds(1.1f);
        agent.isStopped = false;
        lockRotation = false;
        yield return new WaitForSeconds(attackCoolDown);       
    }

    void ChangeAnim(Anima anima)
    {
        animator.SetInteger("animation", (int)anima);
    }
    void FixedUpdate()
    {
        Vector3 playerPosition = Player.instance.GetPosition();
        if(!lockRotation) {
            Vector3 direction = playerPosition - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 4f);
        }
        agent.SetDestination(playerPosition);
    }

    public float DistanceToPlayer()
    {
        return Vector3.Distance(transform.position, Player.instance.GetPosition());
    }
}
