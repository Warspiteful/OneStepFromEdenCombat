using System.Collections;
using System.Collections.Generic;
using Character.Command;
using UnityEngine;

namespace Character.Actions
{
    [CreateAssetMenu]
    public class CannonAttack : Attack
    {
        public override void OnUse(Unit unit)
        {
            Debug.Log(unit.gameObject.name + "Attacked!");
            GameObject bullet = ObjectPool.SharedInstance.GetPooledObject(); 
            if (bullet != null) {
                bullet.transform.position = unit.transform.position + unit.transform.right;
                bullet.transform.rotation = Quaternion.identity;
                bullet.SetActive(true);
            }
            bullet.GetComponent<Projectile>().SetDirection(unit.transform.right);
        }
    }
}
