using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Command
{
    public class UnitCommand
    {
        
        private readonly string commandName;
        
        public UnitCommandCallback Execute { get; private set; }

        public UnitCommand(UnitCommandCallback method, string name)
        {
            Execute = method;
            commandName = name;
        }

        public override string ToString()
        {
            return commandName;
        }
        
        
    }
}