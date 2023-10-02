using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Runaway : MonoBehaviour
{
    public GameObject point; //position of marker on map
    public Transform home; //position where to return if enemy is unseen
    //public Transform run;
    public Transform enemy; //position of enemy
    public Vector3 run1; //vector of random run direction
    public bool flee; //check if unit runs away;
    public bool visible; //checking if enemy is spotted
    public float timer; //interval if checking enemy distance
    public float randompause; //time left to check enemy distance
    public float range; //distance between unit and enemy
    public float contact; //distance on which unit starts to run away
    public float rundistance; //distance on which unit runs away when he spots an enemy
    public int direction;

    System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        range = Vector3.Distance(enemy.position, transform.position);
        if(range <= contact) { visible = true; } else { visible = false; }
        if(visible && !flee) { flee = true; timer = 3; }
        if (flee && visible) { randompause -= Time.deltaTime; }
        if (flee && !visible) { timer -= Time.deltaTime; }
        if(timer <= 0) { flee = false; timer = Mathf.Clamp(timer, 0, 3); point.transform.position = home.transform.position; }
        if(randompause <= 0) 
        { 
            randompause += 0.5f;
            Vector3 searchWayRight = new Vector3(20,0,0);
            Vector3 searchWayLeft = new Vector3(-20, 0, 0);
            Vector3 searchWayBehind = new Vector3(0, 0, -20);
            Vector3 searchWay = new Vector3(0, 0, 0);
            if (direction == 0) { searchWay = searchWayRight; }
            if (direction == 1) { searchWay = searchWayLeft; }
            if (direction == 2) { searchWay = searchWayBehind; }


            if (SearchRandom(transform.position + searchWay, rundistance, out run1)) //pass in our centre point and radius of area
            {
                System.Random rng = new System.Random();
                point.transform.position = run1;
            }
            else
            {
                randompause = 0.001f;
            }
        }

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


}
