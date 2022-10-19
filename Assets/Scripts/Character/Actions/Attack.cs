using System.Collections;
using System.Collections.Generic;
using Character.Command;
using UnityEngine;

namespace Character.Actions
{
    public abstract class Attack : ScriptableObject
    {
        public float cooldown;
        public abstract void OnUse(Unit unit);
    }
}
