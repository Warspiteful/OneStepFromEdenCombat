using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Actions
{
    [CreateAssetMenu]
    public class CannonAttack : Attack
    {
        [SerializeField] private GameObject projectile;
        public override void OnUse()
        {
            //PLACEHOLDER
            Instantiate(projectile);
        }
    }
}
