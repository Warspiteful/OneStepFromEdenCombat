using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    

public class Unit : MonoBehaviour
{
    private UnitStateMachine _stateMachine;

    private InputController input; 

    private void Awake()
    {
        input = GetComponent<InputController>();
        _stateMachine = new UnitStateMachine(this);
    }

    private void Start()
    {
        _stateMachine.ChangeState(_stateMachine.IdleState);
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    
    }
}
