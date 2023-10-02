using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneState : State
{
    private AI_Behaviour _ai_behaviour;
    public CutsceneState(AI_Behaviour ai_behaviour)
    {
        _ai_behaviour = ai_behaviour;
    }
    public override void Enter()
    {
        base.Enter();
       // Debug.Log("CinematicEnter");
       // Debug.Log(_ai_behaviour.name + " 5");
        

    }

    public override void Exit()
    {
        base.Exit();
       // Debug.Log("MoveExit");
    }

    public override void Update()
    {
        base.Update();
       // Debug.Log("Moving");
    }
}
