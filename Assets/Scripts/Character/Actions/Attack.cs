using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Actions
{
    public abstract class Attack : ScriptableObject
    {
        public int cooldown;
        public abstract void OnUse();
    }
}
