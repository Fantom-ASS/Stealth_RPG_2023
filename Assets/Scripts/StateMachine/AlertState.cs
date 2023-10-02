using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class AlertState : State
{
    private UnitData _unit_data;
    private float time;
    private int points;

    public AlertState(UnitData unit_data)
    {
        _unit_data = unit_data;
    }
    public override void Enter()
    {
        Debug.Log(_unit_data.gameObject.name + " is alerted");
        time = _unit_data.alerttime;
        points = _unit_data.alertpoints;
        base.Enter();
        _unit_data.movetype = 3;     
        _unit_data.animator.SetInteger("movetype", 3);
        _unit_data.agent.speed = _unit_data.speed_run;
        if (_unit_data.agent.isStopped)
        {
            _unit_data.agent.isStopped = false;
            _unit_data.animator.SetBool("run", true);
        }
    }
    public override void Exit()
    {
        base.Exit();
        //  Debug.Log("MoveExit");
    }
    public override void Update()
    {
        base.Update();
        if (_unit_data.agent.remainingDistance <= 1 && !_unit_data.agent.isStopped) { _unit_data.agent.isStopped = true; }
        if (_unit_data.agent.isStopped) { time -= Time.deltaTime; _unit_data.animator.SetBool("move", false); }
        if (!_unit_data.agent.isStopped) { _unit_data.animator.SetBool("move", true); }
        if (time <= 0)
        {
            if (points > 0)
            {
                time = _unit_data.alerttime;
                points -= 1;
            }
            else
            {
                _unit_data.agent.isStopped = false;
                _unit_data.animator.SetBool("move", true);
                _unit_data.animator.SetInteger("movetype", 2);
                _unit_data.agent.speed = _unit_data.speed_walk;
                _unit_data.Calm();
            }
        }
        //after approaching the last enemy position he stops and starts to check random points near
        if (_unit_data.agent.remainingDistance <= 1 && !_unit_data.agent.isStopped)
        {
            _unit_data.agent.isStopped = true;
            System.Random rng = new System.Random();
            time = rng.Next(1, 2);
        }
        //bot periodically checks some random nearby rositions
        if (_unit_data.agent.isStopped && time > 0)
        {
            time -= 1 * Time.deltaTime;
        }
        if (time <= 0)
        {
            //quantity of checks
            if (points > 0)
            {
                //unit chooses random point at navmesh in some range and moves there
                Vector3 point;
                if (_unit_data.SearchRandom(_unit_data.transform.position, _unit_data.alertrange, out point)) //pass in our centre point and radius of area
                {
                    _unit_data.agent.isStopped = false;
                    _unit_data.agent.SetDestination(point);
                    System.Random rng = new System.Random();
                    time = rng.Next(1, 3);
                    points -= 1;
                }
            }
            else
            {
                _unit_data.alert = false;
                _unit_data.point = null;
                _unit_data.Calm();

            }
        }
        if (_unit_data.unitsEnemies.Count > 0)
        {
            _unit_data.Fight();
        }



    }
}
