using System;
using System.Collections;
using System.Collections.Generic;
using Character.Command;
using UnityEngine;

namespace Character.Attacks
{
    public class Projectile : Attack
    {
        
        private float lifeTime;

        private float currentLifetime;
        [SerializeField] private Vector3 direction;

        private int damage;

        private Rigidbody2D rb;

        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            direction = Vector3.forward;
            rb = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Setup(Vector3 dir, int damage, float speed, Sprite sprite, float lifeTime)
        {
            direction = dir;
            this.lifeTime = lifeTime;
            this.damage = damage;
            rb.velocity = dir * speed;
            _spriteRenderer.sprite = sprite;
        }

        private void OnEnable()
        {
            currentLifetime = lifeTime;
        }


        private void OnTriggerEnter2D(Collider2D col)
        {
            Unit unit = col.gameObject.GetComponent<Unit>();
            if (unit)
            {
                unit.TakeDamage(damage);
            }

            if (col.gameObject.CompareTag("Damagable"))
            {
                gameObject.SetActive(false);
            }


        }

        // Update is called once per frame
        void Update()
        {
            if (currentLifetime < 0)
            {
                gameObject.SetActive(false);
            }

            currentLifetime -= Time.deltaTime;
        }
    }
}