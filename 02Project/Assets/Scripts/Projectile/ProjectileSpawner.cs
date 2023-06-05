using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ProjectileSpawner : MonoBehaviour
{

    public GameObject Bullet;

    public Transform ShootPointLeft;
    public Transform ShootPointCenter;
    public Transform ShootPointRight;

    public float FireRate;

    public float Type;

    public float Level;

    Timer spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = FireRate;
        spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Shoot( Transform enemyTarget)
    {
        if (spawnTimer.Finished)
        {
            if (Type == 1)
            {
                if (Level == 1)
                {
                    SpawnProjectile(enemyTarget, ShootPointCenter);
                }
                if (Level == 2)
                {
                    SpawnProjectile(enemyTarget, ShootPointLeft);
                    SpawnProjectile(enemyTarget, ShootPointRight);
                }
                if (Level == 3)
                {
                    SpawnProjectile(enemyTarget, ShootPointCenter);
                }
            }
            if (Type == 2)
            {
                if (Level == 1)
                {
                    SpawnProjectile(enemyTarget, ShootPointCenter);
                }   
                if (Level == 2)
                {
                    SpawnProjectile(enemyTarget, ShootPointLeft);
                    SpawnProjectile(enemyTarget, ShootPointRight);
                }
                if (Level == 3)
                {
                    SpawnProjectile(enemyTarget, ShootPointCenter);
                }
            }
            if (Type == 3)
            {
                if (Level == 1)
                {
                    SpawnProjectile(enemyTarget, ShootPointCenter);
                }
                if (Level == 2)
                {
                    SpawnProjectile(enemyTarget, ShootPointLeft);
                    SpawnProjectile(enemyTarget, ShootPointRight);
                }
                if (Level == 3)
                {
                    SpawnProjectile(enemyTarget, ShootPointLeft);
                    SpawnProjectile(enemyTarget, ShootPointCenter);
                    SpawnProjectile(enemyTarget, ShootPointRight);
                }
            }
            spawnTimer.Run();
        }
    }

    private void SpawnProjectile(Transform enemyTarget, Transform ShootPoint)
    {
        GameObject projectileGO = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
        Projectile projectile = projectileGO.GetComponent<Projectile>();
        if (projectile != null)
        {
            projectile.SetEnemy(enemyTarget);
        }
    }
}
