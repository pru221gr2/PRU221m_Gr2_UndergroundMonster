using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] protected float moveSpeed = 10f;
    [SerializeField] private float minDistanceToDealDamage = 0.1f;

    public float Damage { get; set; }

    protected EnemyMovement enemyTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Turret.instance.Enemies.Count != 0)
        {
            enemyTarget = Turret.instance.Enemies[0];
        }
        if (enemyTarget != null)
        {
            MoveProjectile();
            RotateProjectile();
        }
    }

    private void RotateProjectile()
    {
        Vector3 enemyPos = enemyTarget.transform.position - transform.position;
        float angle = Vector3.SignedAngle(transform.up, enemyPos, transform.forward);
        transform.Rotate(0f, 0f, angle);
    }

    private void MoveProjectile()
    {
        transform.position = Vector2.MoveTowards(transform.position, enemyTarget.transform.position, moveSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
