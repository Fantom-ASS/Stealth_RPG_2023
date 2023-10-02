using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;
using UnityEngine.XR;
using static Unity.Mathematics.math;
using static UnityEngine.GraphicsBuffer;

public class MoveTo : MonoBehaviour
{
    public bool alert;
    public bool fear;

    public bool gone; //imitator of enemies list = 0
    public bool turn;

    public bool turning;
    public float rotSpeed;
    public bool positive;
    public float timecount;
    public Quaternion rot;
    public float stop;
    public Transform clickPosition;


    public NavMeshAgent agent; //agent of this unit
    public Transform []  patrol; //array of points that unit visits when he's calm
    public Transform search; //points that unit visits when looks for the enemy
    public Transform enemy;
    public Transform center;
    public float[] rotations_patrol; //list of pauses duration
    public float[] pauses_patrol; //list of pauses duration
    public float pause_current; //is used to keep bot in idle pose
    public float rotator; //used to rotate character when agent is inactive
    public float angleturn; //checking on which angle unit already turned

    public float range; //range in which random point should be find
    public int point; //used to understand the patrol way
    public int check; //used to find lost enemy
    System.Random random = new System.Random();


    // Start is called before the first frame update
    void Start()
    {


        pause_current = 0.1f;
        agent.SetDestination(patrol[0].transform.position);
       // Debug.Log(patrol.Length);
    }

    // Update is called once per frame
    void Update()
    {
        //unit loses enemy
        if (gone)
        {
            
            if(enemy!= null)
            {
                search = enemy.transform;
                enemy = null;
                agent.SetDestination(search.transform.position);
                Debug.Log(search);
                System.Random rng = new System.Random();
                check = rng.Next(4, 6);


            }
        }
        if (turn)
        {
            turn = false;
            System.Random rng = new System.Random();
            rotator = rng.Next(-180, 180);
            angleturn = rotator;
        }

        if(rotator != 0)
        {
            transform.Rotate(0, rotator*Time.deltaTime, 0);
            angleturn += rotator;
            if(rotator == angleturn) { rotator = 0; }
        }
        // rotator += 1;

        //in calm state character have a loop of actions that he does if nothing and nobody distract him
        if (!alert)
            {
            Transform current = patrol[point].transform;
            //after reaching point agent stops, timer starts and target changes on the nex one
            if (agent.remainingDistance <= 1 && !agent.isStopped)
            {
                agent.isStopped = true;
                agent.velocity = Vector3.zero;
                pause_current = pauses_patrol[point];
                PatrolPoint();
                turning = true;
                timecount = 0;

                

            }
            //after timer runs out agent gets new destination and starts moving
            if (agent.isStopped)
            {
                Quaternion angle = Quaternion.Euler(0, rotations_patrol[point], 0);
                Vector3 relativePos = current.position - transform.position;

                //ROTATION
                Quaternion rotation = Quaternion.Slerp(transform.rotation, angle, rotSpeed * Time.deltaTime);
                rotation.x = 0;
                rotation.z = 0;
                transform.rotation = rotation;





                if (pause_current > 0)
                {
                    pause_current -= 1 * Time.deltaTime;
                }
                else
                {
                    agent.SetDestination(patrol[point].transform.position);
                    agent.isStopped = false;
                    pause_current = 0.1f;
                }
            }
        } else {
            //if unit doesn't afraid and is alerted, he checks what to do
            if (!fear)
            {
                //if bot notice enemy he chases him
                if(enemy != null) 
                {
                    agent.SetDestination(enemy.transform.position);
                    agent.isStopped = false;
                    pause_current = 0.1f;
                }
                else
                {
                    //if bot loses an enemy he runs to the last point where he saw him
                    


                    //after approaching the last enemy position he stops and starts to check random points near
                    if ( agent.remainingDistance <= 1 && !agent.isStopped)
                    {
                        agent.isStopped = true;
                        System.Random rng = new System.Random();
                        pause_current = rng.Next(1, 2);
                       // check = rng.Next(2, 4);

                    }
                    //bot periodically checks some random nearby rositions
                    if (agent.isStopped && pause_current > 0)
                    {
                        pause_current -= 1 * Time.deltaTime;
                    }
                    if(pause_current <=0) 
                    {
                        //quantity of checks
                        if (check > 0)
                        {
                            //unit chooses random point at navmesh in some range and moves there
                            Vector3 point;
                            if (SearchRandom(transform.position, range, out point)) //pass in our centre point and radius of area
                            {
                                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                                agent.isStopped = false;
                                agent.SetDestination(point);   
                               // Debug.Log(point);
                                System.Random rng = new System.Random();
                                pause_current = rng.Next(1, 3);
                                check -= 1;
                            }
                        }
                        else
                        {
                            alert = false;
                            agent.SetDestination(patrol[point].transform.position);
                            agent.isStopped = false;
                            pause_current = 0.1f;
                        }
                        
                    }

                }
                
            }

        }
        




    }

    void PatrolPoint()
    {
        if (point < patrol.Length-1)
        {
            point += 1;
        }
        else
        {
            point = 0;
        }
    }

    bool SearchRandom(Vector3 center, float range, out Vector3 result)
    {
        range = random.Next(2, 5);
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


}
