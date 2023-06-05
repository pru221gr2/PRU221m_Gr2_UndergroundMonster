using Assets.Scripts.Enemy;
using Assets.Scripts.Turret;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float moveSpeed;

    private EnemyScanner _enemyScanner;

    private Transform enemyTarget;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemyTarget != null)
        {
            MoveProjectile();
            RotateProjectile();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void RotateProjectile()
    {
        Vector3 enemyPos = enemyTarget.transform.position - transform.position;
        float angle = Vector3.SignedAngle(transform.up, enemyPos, transform.forward);
        transform.Rotate(0f, 0f, angle);
    }

    protected virtual void MoveProjectile()
    {
        transform.position = Vector2.MoveTowards(transform.position, enemyTarget.transform.position, moveSpeed*Time.deltaTime);
    }

    public void SetEnemy(Transform enemy)
    {
        enemyTarget = enemy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
