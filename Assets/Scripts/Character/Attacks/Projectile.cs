using System;
using System.Collections;
using System.Collections.Generic;
using Character.Command;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float lifeTime;
    private float currentLifetime;
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

    private void OnEnable()
    {
        currentLifetime = lifeTime;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        Unit unit = col.gameObject.GetComponent<Unit>();
        if (unit)
        {
            unit.TakeDamage(5);
        }
        if(col.gameObject.CompareTag("Damagable")){
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
