using System.Collections;
using System.Collections.Generic;
using Character.Command;
using UnityEngine;

namespace Character.Actions
{
    [CreateAssetMenu]
    public class CannonAttack : Attack
    {
        [SerializeField] private Projectile projectile;
        public override void OnUse(Unit unit)
        {
            //PLACEHOLDER
            Projectile proj = Instantiate(projectile,unit.transform.position + unit.transform.right, Quaternion.identity);
            proj.SetDirection(unit.transform.right);
        }
    }
}
