using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public class RunAwayAI : MonoBehaviour
{
    public Transform target; // The object to run away from
    public float runDistance = 5f; // Distance at which the AI starts running
    public float moveSpeedcur = 5f; // Speed at which the AI moves
    public bool obstacle;
    public bool turn;
    public float timer; //time left to check enemy distance
    public float deftime; //interval if checking enemy distance
    private NavMeshAgent agent;
    private Vector3 run1; //vector of random run direction
    public bool calm;
    System.Random random = new System.Random();

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = deftime;
        calm = true;

        //bool Boolean = Random.Range(0, 2) != 0;
    }

    private void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position); // Calculate the distance between AI and target
        if (distanceToTarget < runDistance && !obstacle ) // If the target is within the runDistance, start running away
        {
            calm = false;
            timer -= Time.deltaTime;
            Vector3 moveDirection = transform.position - target.position;
            Vector3 targetPosition = transform.position + moveDirection.normalized * runDistance;            
            agent.SetDestination(targetPosition); // Move the AI away from the target
            if (agent.speed == 0) { agent.speed = moveSpeedcur; }
            float speed = Vector3.Distance(new Vector3(0,0,0), agent.velocity);
            if (timer < 0) 
            { 
                if (speed < moveSpeedcur * 0.8) { Debug.Log("OBSTACLE"); obstacle = true; turn = true; }
                timer = deftime;
            }
        }else if (distanceToTarget < runDistance && obstacle)
        {
            if (turn)
            {
                calm = false;
                turn = false;
                Vector3 searchWayRight = new Vector3(runDistance, 0, 0);
                Vector3 searchWayLeft = new Vector3(-runDistance, 0, 0);
                Vector3 searchWayBehind = new Vector3(0, 0, -runDistance);
                Vector3 searchWay = new Vector3(0, 0, 0);
                bool Boolean = Random.Range(0, 2) != 0;
                if (Boolean)
                {
                    searchWay = searchWayRight;
                    if (SearchRandom(transform.position + searchWay, runDistance, out run1)) //pass in our centre point and radius of area
                    {
                        System.Random rng = new System.Random();
                        agent.SetDestination(run1);
                    }
                    else
                    {
                        searchWay = searchWayLeft;
                        if (SearchRandom(transform.position + searchWay, runDistance, out run1)) //pass in our centre point and radius of area
                        {
                            System.Random rng = new System.Random();
                            agent.SetDestination(run1);
                        }
                        else
                        {
                            searchWay = searchWayBehind;
                            if (SearchRandom(transform.position + searchWay, runDistance, out run1)) //pass in our centre point and radius of area
                            {
                                System.Random rng = new System.Random();
                                agent.SetDestination(run1);
                            }
                            else
                            {
                                agent.SetDestination(transform.position);
                            } } } }
                else
                {
                    searchWay = searchWayLeft;
                    if (SearchRandom(transform.position + searchWay, runDistance, out run1)) //pass in our centre point and radius of area
                    {
                        System.Random rng = new System.Random();
                        agent.SetDestination(run1);
                    }
                    else
                    {
                        searchWay = searchWayRight;
                        if (SearchRandom(transform.position + searchWay, runDistance, out run1)) //pass in our centre point and radius of area
                        {
                            System.Random rng = new System.Random();
                            agent.SetDestination(run1);
                        }
                        else
                        {
                            searchWay = searchWayBehind;
                            if (SearchRandom(transform.position + searchWay, runDistance, out run1)) //pass in our centre point and radius of area
                            {
                                System.Random rng = new System.Random();
                                agent.SetDestination(run1);
                            }
                            else
                            {
                                agent.SetDestination(transform.position);
                            }

                        } } } } 
            if (agent.remainingDistance == 0) { Stop(); } //after escaping with obstacle unit stops and ready to check enemies again
        } else { Stop(); }
    }

    public bool SearchRandom(Vector3 center, float range, out Vector3 result)
    {
        range = random.Next(2, 15);
        Vector3 randomPoint = center + UnityEngine.Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, range, NavMesh.AllAreas))
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    public void Stop()
    {
        calm = true;
        agent.velocity = Vector3.zero;
        agent.speed = 0f;
        agent.SetDestination(transform.position);
        obstacle = false;
        timer = deftime;

        
        
    }

}