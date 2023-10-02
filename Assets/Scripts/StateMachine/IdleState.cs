using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class IdleState : State
{
    private UnitData _unit_data;
    //private UnitData _enemy_data;
    public IdleState(UnitData unit_data)
    {
        _unit_data = unit_data;
    }
    //is used if a hero doesn't move or do anything else
    public override void Enter()
    {
        base.Enter();
        Debug.Log(_unit_data.gameObject.name + " is in idle");
        _unit_data.agent.SetDestination(_unit_data.transform.position);
        _unit_data.agent.isStopped = true;
        _unit_data.animator.SetBool("move", false);
        _unit_data.animator.SetBool("ready", false);
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        //IDLE
        if(_unit_data.unitsEnemies.Count > 0 && _unit_data.agressive) //ONLY FOR TESTS, NEED MORE COMPLEX CONDITION
        {
            Debug.Log(_unit_data.gameObject.name + " is agressive and spotted enemy");
            //_enemy_data = _unit_data.unitsEnemies[0].GetComponent<UnitData>();
            //_unit_data.Attack();
            for (int i = 0; i < _unit_data.unitsEnemies.Count; i++)
            {
                UnitData edata = _unit_data.unitsEnemies[i].GetComponent<UnitData>();
                if(edata.unitsEnemies.Count > 0) { _unit_data.Attack(); }

            }




        }


        base.Update();
    }
}
