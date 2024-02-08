using UnityEngine;
using UnityEngine.AI;

public class EnnemyScript : MonoBehaviour
{
    private NavMeshAgent agent;
    public float fixedYposition = 0.0f;
    private Entity stats;
    private void Start()
    {
        stats = GetComponent<Entity>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = stats.GetSpeed();
        stats.SpeedChanged += ChangeSpeed;
    }
    
    private void ChangeSpeed(float newSpeed)
    {
        agent.speed = newSpeed;
    }
    void FixedUpdate()
    {
        agent.SetDestination(Player.instance.GetPosition());
        Vector3 position = transform.position;
        position.y = fixedYposition;
        transform.position = position;
    }
}
