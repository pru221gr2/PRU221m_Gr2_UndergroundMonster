using Assets.Scripts.Enemy;
using Assets.Scripts.Turret;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject Gun;

    Vector2 Direction;

    private EnemyScanner _enemyScanner;
    private ProjectileSpawner _projectileSpawner;
    private bool _isHover = false;

    public float health;
    private void Awake()
    {
        _enemyScanner = GetComponentInChildren<EnemyScanner>();
        _projectileSpawner = GetComponent<ProjectileSpawner>();
    }

    private void Start()
    {
        InvokeRepeating("ScanEnemies", 0f, 0.1f);
    }

    private void Update()
    {
        if (!_isHover && _enemyScanner.IsTargetFound())
        {
            RotateTowardsTarget();
            _projectileSpawner.Shoot(_enemyScanner.GetTarget());    
        }
    }

    private void ScanEnemies()
    {
        _enemyScanner.updateNearestEnemy();
    }

    public void RemoveTower()
    {
        Destroy(gameObject);
    }

    public void HoverMode(bool hover)
    {
        _isHover = hover;
    }
    private void RotateTowardsTarget()
    {
        Vector2 targetPos = _enemyScanner.GetTarget().position;
        Direction = targetPos - (Vector2)Gun.transform.position;
        Gun.transform.up = Direction;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        var bases = GameObject.FindGameObjectsWithTag("BaseTower");
        foreach (var b in bases)
        {
            if (b.transform.position == transform.position)
            {
                b.GetComponent<ClickToBaseTower>().OnMouseDown();
            }
        }
    }
}
