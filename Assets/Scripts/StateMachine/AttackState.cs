using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : State
{
    private UnitData _unit_data;
    //private UnitData _tgt_data;
    private GameObject attacktarget;
    private float time;
    public AttackState(UnitData unit_data)
    {
        _unit_data = unit_data;
    }
    //is used if a hero doesn't move or do anything else
    public override void Enter()
    {
        base.Enter();
        Debug.Log(_unit_data.gameObject.name + " is in attack");
        //_tgt_data = _unit_data.enemyChaseTarget.GetComponent<UnitData>();
        _unit_data.agent.SetDestination(_unit_data.unitsEnemies[0].transform.position);
        _unit_data.agent.isStopped = false;
        _unit_data.animator.SetBool("move", true);
        _unit_data.animator.SetBool("ready", true);
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        if (_unit_data.unitsEnemies.Count > 0)
        {
            if (_unit_data.unitsAttackable.Count == 0)
            {
                _unit_data.agent.SetDestination(_unit_data.enemyChaseTarget.transform.position);
                _unit_data.agent.isStopped = false;
                _unit_data.animator.SetBool("attack", false);
                _unit_data.animator.SetBool("move", true);
            }
            else
            {
                _unit_data.agent.isStopped = true;
                Vector3 directionToTarget = _unit_data.enemyChaseTarget.transform.position - _unit_data.transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                _unit_data.transform.rotation = Quaternion.Slerp(_unit_data.transform.rotation, targetRotation, Time.deltaTime * 10);
                _unit_data.animator.SetBool("attack", true);
                _unit_data.animator.SetBool("move", false);
            }
        }
        else
        {
            _unit_data.animator.SetBool("attack", false);
            _unit_data.animator.SetBool("ready", false);
            _unit_data.Idle();
        }

    }
}
