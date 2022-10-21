using System;
using System.Collections;
using System.Collections.Generic;
using Character.Command;
using UnityEngine;

namespace Character.Actions
{
    public class AttackHandler : MonoBehaviour
    {
        [SerializeField] private List<Attack> _attackList;
        
        [SerializeField] private Attack _attack;

        
        private Unit unit;

        private float coolDown;


        private void Awake()
        {
            coolDown = 0;
            unit = GetComponent<Unit>();
            unit.onAttack += Attack;
            unit.onAttackSwitch += Switch;
            _attack = _attackList[0];
            _attack.isActive = true;

        }

        private void Switch()
        {
            _attack.isActive = false;
            int newIndex = _attackList.IndexOf(_attack) + 1;
            if (newIndex >= _attackList.Count)
            {
                newIndex = 0;
            }

            _attack = _attackList[newIndex];
            _attack.isActive = true;

        }

        private void Attack()
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