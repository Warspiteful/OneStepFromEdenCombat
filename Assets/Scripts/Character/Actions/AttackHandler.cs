using System;
using System.Collections;
using System.Collections.Generic;
using Character.Command;
using UnityEngine;

namespace Character.Actions
{
    public class AttackHandler : MonoBehaviour
    {
        [SerializeField] private Attack _attack;
        
        private Unit unit;

        private float coolDown;


        private void Awake()
        {
            coolDown = 0;
            unit = GetComponent<Unit>();
            unit.onAttack += Attack;
        }

        public void Attack()
        {
            if(coolDown <= 0 ){
                _attack.OnUse(unit);
                coolDown = _attack.cooldown;
            }
        }

        private void Update()
        {
            coolDown -= Time.deltaTime;
        }
    }
}