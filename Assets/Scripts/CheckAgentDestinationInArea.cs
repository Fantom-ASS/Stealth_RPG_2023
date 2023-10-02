using UnityEngine;
using UnityEngine.AI;

public class CheckAgentDestinationInArea : MonoBehaviour
{
    public Collider areaCollider; // Assign the collider that defines the area in the Inspector.
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        CheckIfAgentDestinationInArea();
    }

    private void CheckIfAgentDestinationInArea()
    {
        if (agent.pathPending)
            return; // Wait until the agent has computed its path.

        Vector3 destination = agent.destination;

        if (areaCollider.bounds.Contains(destination))
        {
            Debug.Log("Agent's destination is in the specified area.");
        }
        else
        {
            Debug.Log("Agent's destination is NOT in the specified area.");
        }
    }
}