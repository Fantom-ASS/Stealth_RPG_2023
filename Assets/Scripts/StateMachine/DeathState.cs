using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathState : State
{
    private UnitData _unit_data;
    public DeathState(UnitData unit_data)
    {
        _unit_data = unit_data;
    }
    //is used if a hero doesn't move or do anything else
    public override void Enter()
    {
        base.Enter();
        Debug.Log(_unit_data.gameObject.name + " has been killed!");
        _unit_data.regen_total = 0;
        _unit_data.health_cur = 0;
        _unit_data.recover = 0;
        _unit_data.mana_cur = 0;
        _unit_data.animator.SetTrigger("death");

        //REMAKE AFTER NECROMANCY
        _unit_data.vision_range = 0;
        _unit_data.vision_angle = 0;
        _unit_data.hearing_range = 0;
        _unit_data.unitsEnemies.Clear();
        _unit_data.unitsAllies.Clear();
        _unit_data.agent.enabled = false;



    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        //IDLE

        base.Update();
    }
}
