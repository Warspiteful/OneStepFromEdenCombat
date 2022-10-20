using System.Collections;
using System.Collections.Generic;
using Character.Command;
using UnityEngine;

namespace Character.Actions
{
    [CreateAssetMenu]
    public class TileAttack : Attack
    {
        public override void OnUse(Unit unit)
        {
            unit.GetAttackTile();
        }
    }
}