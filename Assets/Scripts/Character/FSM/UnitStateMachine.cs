using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    
public class UnitStateMachine : StateMachine
{
    public Attack AttackState { get; }
    public Move MoveState { get; }
    public Idle IdleState { get; }
    
    public Unit unit { get; }

    public UnitStateMachine(Unit unit)
    {
        this.unit = unit;
        AttackState = new Attack(this);
        MoveState = new Move(this);
        IdleState = new Idle(this);
    }
}
}
