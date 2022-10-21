using System.Collections;
using System.Collections.Generic;
using Character.Command;
using UnityEngine;

namespace Character.Actions
{
    public abstract class Attack : ScriptableObject
    {
        public int damage;

        public DelegateSignal activeChange;

        [SerializeField] private bool _isActive = false;
        
        public Sprite thumbnail;


        public bool isActive
        {
            set
            {
                _isActive = value;
                activeChange?.Invoke();
            }
            get
            {
                return _isActive;
            }
        }

        public float cooldown;
        public abstract void OnUse(Unit unit);
    }
}
