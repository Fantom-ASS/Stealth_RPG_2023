using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EscapeState : State
{
    //private GameObject k99;
    private UnitData _unit_data;
    //private NavMeshAgent agent1;
    //private Transform enemy; // The object to run away from
    private bool obstacle;
    private bool turn;
    private float lefttime; //time left to check enemy distance
    private Vector3 run1; //vector of random run direction
    System.Random random = new System.Random();
    //public float calmtime = 1;

    public EscapeState(UnitData unit_data)
    {
        _unit_data = unit_data;
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log(_unit_data.gameObject.name + " is escaping");
        //agent = _unit_data.agent;
        lefttime = _unit_data.escapetime;
        _unit_data.movetype = 3;
        _unit_data.animator.SetBool("move", true);
        _unit_data.animator.SetInteger("movetype", 3);
        _unit_data.agent.speed = _unit_data.speed_run;
        //k99 = GameObject.Find("999");
        //agent1 = _unit_data.GetComponent<NavMeshAgent>();
        _unit_data.agent.isStopped = false;

    }

    public override void Exit()
    {
        
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        //Vector3 destiny = new Vector3 (0,0,0);
        //agent1.SetDestination(destiny);
        //agent1.isStopped = false;

        //if (_unit_data.enemyChaseTarget != null) { enemy = _unit_data.enemyChaseTarget.transform; } //unit updates the closest enemy if he see it  
        //enemy = _unit_data.enemyChaseTarget.transform;
        
        float distanceToTarget = Vector3.Distance(_unit_data.transform.position, _unit_data.enemyChaseTarget.transform.position);
        if (distanceToTarget < _unit_data.escaperange && !obstacle) // If the target is within the runDistance, start running away
        {
            lefttime -= Time.deltaTime;
            Vector3 moveDirection = _unit_data.transform.position - _unit_data.enemyChaseTarget.transform.position;
            Vector3 targetPosition = _unit_data.transform.position + moveDirection.normalized * _unit_data.escaperange;
            _unit_data.agent.SetDestination(targetPosition); // Move the AI away from the target
            _unit_data.agent.isStopped = false;
            //k99.transform.position = _unit_data.agent.destination;//TEST
            if (_unit_data.agent.speed == 0) { _unit_data.agent.speed = _unit_data.speed_run; }
            float speed = Vector3.Distance(new Vector3(0, 0, 0), _unit_data.agent.velocity);
            if (lefttime < 0)
            {
                if (speed < _unit_data.speed_run * 0.8) { Debug.Log("OBSTACLE"); obstacle = true; turn = true; }
                lefttime = _unit_data.escapetime;
            }
        }
        else if (distanceToTarget < _unit_data.escaperange && obstacle)
        {
            if (turn)
            {
                turn = false;
                _unit_data.agent.isStopped = false;
                Vector3 searchWayRight = new Vector3(_unit_data.escaperange, 0, 0);
                Vector3 searchWayLeft = new Vector3(-_unit_data.escaperange, 0, 0);
                Vector3 searchWayBehind = new Vector3(0, 0, -_unit_data.escaperange);
                Vector3 searchWay = new Vector3(0, 0, 0);
                bool Boolean = Random.Range(0, 2) != 0;
                if (Boolean)
                {
                    searchWay = searchWayRight;
                    if (SearchRandom(_unit_data.transform.position + searchWay, _unit_data.escaperange, out run1)) //pass in our centre point and radius of area
                    {
                        System.Random rng = new System.Random();
                        _unit_data.agent.SetDestination(run1);
                    }
                    else
                    {
                        searchWay = searchWayLeft;
                        if (SearchRandom(_unit_data.transform.position + searchWay, _unit_data.escaperange, out run1)) //pass in our centre point and radius of area
                        {
                            System.Random rng = new System.Random();
                            _unit_data.agent.SetDestination(run1);
                        }
                        else
                        {
                            searchWay = searchWayBehind;
                            if (SearchRandom(_unit_data.transform.position + searchWay, _unit_data.escaperange, out run1)) //pass in our centre point and radius of area
                            {
                                System.Random rng = new System.Random();
                                _unit_data.agent.SetDestination(run1);
                            }
                            else
                            {
                                _unit_data.agent.SetDestination(_unit_data.transform.position);
                            }
                        }
                    }
                }
                else
                {
                    searchWay = searchWayLeft;
                    if (SearchRandom(_unit_data.transform.position + searchWay, _unit_data.escaperange, out run1)) //pass in our centre point and radius of area
                    {
                        System.Random rng = new System.Random();
                        _unit_data.agent.SetDestination(run1);
                    }
                    else
                    {
                        searchWay = searchWayRight;
                        if (SearchRandom(_unit_data.transform.position + searchWay, _unit_data.escaperange, out run1)) //pass in our centre point and radius of area
                        {
                            System.Random rng = new System.Random();
                            _unit_data.agent.SetDestination(run1);
                        }
                        else
                        {
                            searchWay = searchWayBehind;
                            if (SearchRandom(_unit_data.transform.position + searchWay, _unit_data.escaperange, out run1)) //pass in our centre point and radius of area
                            {
                                System.Random rng = new System.Random();
                                _unit_data.agent.SetDestination(run1);
                            }
                            else
                            {
                                _unit_data.agent.SetDestination(_unit_data.transform.position);
                            }

                        }
                    }
                }
            }
            if (_unit_data.agent.remainingDistance == 0) { Stop(); } //after escaping with obstacle unit stops and ready to check enemies again
        }
        else { Stop();  }
        

        //if(calmtime> 0) { calmtime-=Time.deltaTime; } else { _unit_data.fear = false; _unit_data.Calm(); }

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
        _unit_data.agent.velocity = Vector3.zero;
        _unit_data.agent.speed = 0f;
        _unit_data.agent.SetDestination(_unit_data.transform.position);
        obstacle = false;
        lefttime = _unit_data.escapetime;
        _unit_data.agent.isStopped = true;
        //_unit_data.agent.SetDestination(_unit_data.point.transform.position);
        _unit_data.Alert();
    }
}
