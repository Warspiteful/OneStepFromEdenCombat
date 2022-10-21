using System.Collections;
using System.Collections.Generic;
using Character.Attacks;
using Character.Command;
using UnityEngine;
using UnityEngine.UI;

namespace Character.Actions
{
    [CreateAssetMenu]
    public class CannonAttack : Attack
    {

        [SerializeField] private Sprite sprite;
        [SerializeField] private float speed;
        [SerializeField] private float lifeTime;



        public override void OnUse(Unit unit)
        {
            Debug.Log(unit.gameObject.name + "Attacked!");
            GameObject bullet = ProjectilePool.SharedInstance.GetPooledObject(); 
            if (bullet != null) {
                bullet.transform.position = unit.transform.position + unit.transform.right;
                bullet.transform.rotation = Quaternion.identity;
                bullet.SetActive(true);
            }
            bullet.GetComponent<Projectile>().Setup(unit.transform.right, damage, speed, sprite, lifeTime);
        }
    }
}
