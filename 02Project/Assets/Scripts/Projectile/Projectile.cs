using Assets.Scripts.Enemy;
using Assets.Scripts.Turret;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float moveSpeed;

    public float damage;

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

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBot1 enemy1 = collision.gameObject.GetComponent<EnemyBot1>();
        if (enemy1 != null && enemy1.Health > 0)
        {
            enemy1.TakeDamage(damage);
            Destroy(gameObject);
        }
        EnemyBot2 enemy2 = collision.gameObject.GetComponent<EnemyBot2>();
        if (enemy2 != null && enemy2.Health > 0)
        {
            enemy2.TakeDamage(damage);
            Destroy(gameObject);
        }
        EnemyBot3 enemy3 = collision.gameObject.GetComponent<EnemyBot3>();
        if (enemy3 != null && enemy3.Health > 0)
        {
            enemy3.TakeDamage(damage);
            Destroy(gameObject);
        }
        EnemyBot4 enemy4 = collision.gameObject.GetComponent<EnemyBot4>();
        if (enemy4 != null && enemy4.Health > 0)
        {
            enemy4.TakeDamage(damage);
            Destroy(gameObject);
        }
        EnemyBot5 enemy5 = collision.gameObject.GetComponent<EnemyBot5>();
        if (enemy5 != null && enemy5.Health > 0)
        {
            enemy5.TakeDamage(damage);
            Destroy(gameObject);
        }
        EnemyBot6 enemy6 = collision.gameObject.GetComponent<EnemyBot6>();
        if (enemy6 != null && enemy6.Health > 0)
        {
            enemy6.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
