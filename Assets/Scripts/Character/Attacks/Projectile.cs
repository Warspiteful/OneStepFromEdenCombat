using System;
using System.Collections;
using System.Collections.Generic;
using Character.Command;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float lifeTime;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;

    private Rigidbody2D rb;

    private void Awake()
    {
        direction = Vector3.forward;
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
        rb.velocity = dir * speed;
    }

    
    private void OnTriggerEnter2D(Collider2D col)
    {
        Unit unit = col.gameObject.GetComponent<Unit>();
        if (unit)
        {
            unit.TakeDamage(5);
        }
        if(col.gameObject.CompareTag("Damagable")){
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }

        lifeTime -= Time.deltaTime;
    }
}
