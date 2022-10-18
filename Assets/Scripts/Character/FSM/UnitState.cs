using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    

public class UnitState : IState
{
    protected UnitStateMachine stateMachine;
    public void Enter()
    {
//        AddInputActionsCallbacks();
    }

    public void Exit()
    {
//        RemoveInputActionsCallbacks();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }

    public void PhysicsUpdate()
    {
        throw new System.NotImplementedException();
    }
    
    public UnitState(UnitStateMachine unitStateMachine)
    {

    }

    protected void AddInputActionsCallbacks()
    {
        
    }
    
    protected void RemoveInputActionsCallbacks()
    {
        
    }

}}
