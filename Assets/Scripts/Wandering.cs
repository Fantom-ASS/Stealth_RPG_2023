using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wandering : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;

    public NavMeshAgent agent;
    public bool travel;
    public float timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(travel)
        {
            agent.SetDestination(point1.transform.position);

        }
        else
        {
            agent.SetDestination(point2.transform.position);
        }
        if (timer < 0)
        {
            travel = !travel;
            timer = 3;
        }
        timer -= Time.deltaTime;

    }
}
