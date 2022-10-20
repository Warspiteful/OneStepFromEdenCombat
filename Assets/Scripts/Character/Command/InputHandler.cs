using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Command
{
    public abstract class InputHandler 
    {
        
        private UnitCommand currentCommand;

        public DelegateSignal newCommandEnqueued;
        
        protected void AddCommand(UnitCommand command)
        {
            if (currentCommand != null)
            {
                return;
            }

            currentCommand = command;
            newCommandEnqueued?.Invoke();
        }

        public abstract void Initialize();

        public virtual IEnumerator StartBrain()
        {
            yield return null;
        }
        

        public UnitCommand GetCommand()
        {
            return currentCommand;
        }

        public void ResetCommand()
        {
            currentCommand = null;
        }
        
        protected readonly UnitCommand MoveUp = new UnitCommand(delegate (Unit unit)
        {
            unit.Move(Direction.UP);
        }, "MoveUp");
        
        protected  readonly UnitCommand MoveDown = new UnitCommand(delegate (Unit unit)
        {
            unit.Move(Direction.DOWN);
        }, "MoveDown");
        
        protected  readonly UnitCommand MoveLeft = new UnitCommand(delegate (Unit unit)
        {
            unit.Move(Direction.LEFT);
        }, "MoveLeft");
        
        protected  readonly UnitCommand MoveRight = new UnitCommand(delegate (Unit unit)
        {
            unit.Move(Direction.RIGHT);
        }, "MoveRight");
        
        protected readonly UnitCommand Attack = new UnitCommand(delegate (Unit unit)
        {
            unit.Attack();
        }, "Attack");
        
                protected readonly UnitCommand Switch = new UnitCommand(delegate (Unit unit)
                {
                    unit.Switch();
                }, "Switch");

        
    }
}