using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Command
{
    public class UnitController : MonoBehaviour
    {

        
        private Unit unit;
        
        private InputHandler inputSystem;

        private void Start()
        {
            unit = GetComponent<Unit>();
            inputSystem = unit.GetInputHandler();
            inputSystem.Initialize();
            inputSystem.newCommandEnqueued += ExecuteCommand;
            StartCoroutine(inputSystem.StartBrain());
        }

        private void ExecuteCommand()
        {
            if (!unit.isCommandFinished())
            {
                inputSystem.ResetCommand();
                return;
            }
            inputSystem.GetCommand().Execute(unit);
            inputSystem.ResetCommand();

        }
        
    }
}
