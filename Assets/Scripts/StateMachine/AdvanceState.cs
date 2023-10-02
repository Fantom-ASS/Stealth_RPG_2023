using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AdvanceState : State
{
    private UnitData _unit_data;
    private float time;
    public AdvanceState(UnitData unit_data)
    {
        _unit_data = unit_data;
    }
    //is used if a hero doesn't move or do anything else
    public override void Enter()
    {
        base.Enter();
        Debug.Log(_unit_data.gameObject.name + " is calm");
        time = _unit_data.pauses[_unit_data.curpoint];
        _unit_data.movetype = 2;
        _unit_data.animator.SetInteger("movetype", 2);
        _unit_data.agent.speed = _unit_data.speed_walk;
        _unit_data.agent.SetDestination(_unit_data.patrol[_unit_data.curpoint].transform.position);
        if (_unit_data.agent.remainingDistance > 0.25f && _unit_data.agent.isStopped) 
        {
            _unit_data.agent.isStopped = false;
            _unit_data.animator.SetBool("move", true);
        }
        else
        {
            _unit_data.agent.isStopped = true;//test
            _unit_data.animator.SetBool("move", false);//test
        }

    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        if (_unit_data.agent.remainingDistance <= 0.25f && !_unit_data.agent.isStopped){_unit_data.agent.isStopped = true;}
        if (_unit_data.agent.isStopped) { time -= Time.deltaTime; _unit_data.animator.SetBool("move", false); }
        if (time <= 0) { 
            if(_unit_data.curpoint < _unit_data.pauses.Length)
            {
                time = _unit_data.pauses[_unit_data.curpoint];
                _unit_data.curpoint += 1;
            }
            else
            {
                _unit_data.curpoint = 0;
                time = _unit_data.pauses[_unit_data.curpoint];
            }
            _unit_data.agent.SetDestination(_unit_data.patrol[_unit_data.curpoint].transform.position);
            _unit_data.point = _unit_data.patrol[_unit_data.curpoint].transform;
            _unit_data.agent.isStopped = false;
            _unit_data.animator.SetBool("move", true);
        }
        if(_unit_data.agent.isStopped == true) { _unit_data.TurnPatrol(); }
        base.Update();
       // if (_unit_data.alert) { _unit_data.Alert(); }
    }
}
