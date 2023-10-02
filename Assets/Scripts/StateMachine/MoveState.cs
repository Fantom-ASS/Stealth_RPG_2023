using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MoveState : State
{
    private UnitData _unit_data;
    public MoveState(UnitData unit_data)
    {
        _unit_data = unit_data;
    }
    //is used if a hero doesn't move or do anything else
    public override void Enter()
    {
        base.Enter();
        _unit_data.agent.isStopped = false;
        _unit_data.animator.SetBool("move", true);
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        if (_unit_data.transform.position == _unit_data.agent.destination) {_unit_data.agent.isStopped = true; }
        if (_unit_data.agent.pathStatus == NavMeshPathStatus.PathPartial) { _unit_data.agent.destination = _unit_data.transform.position; }
        if (_unit_data.agent.isStopped == true) { _unit_data.TurnPatrol(); if (_unit_data.player != 0) { _unit_data.Idle(); } }
        base.Update();
    }
}
