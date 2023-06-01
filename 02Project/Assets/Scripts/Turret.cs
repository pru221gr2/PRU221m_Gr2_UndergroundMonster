using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public static Turret instance;

    public List<EnemyMovement> Enemies = new List<EnemyMovement>();

    public float Range;

    public GameObject Gun;

    public GameObject Bullet;

    public Transform ShootPoint;

    public float Force;
    Timer timer;

    Vector2 Direction;
    Vector3 Direction1;
    private Rigidbody2D rb;
    public EnemyMovement CurrentEnemyTarget;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 2;
        timer.Run();
        GetComponent<CircleCollider2D>().radius = Range;
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentEnemyTarget();
        RotateTowardsTarget();
    }


    private void GetCurrentEnemyTarget()
    {
        if(Enemies.Count <= 0)
        {
            CurrentEnemyTarget = null;
            return;
        }
        CurrentEnemyTarget = Enemies[0];
    }

    private void RotateTowardsTarget()
    {
        if(CurrentEnemyTarget == null)
        {
            return;
        }
        Vector2 targetPos = CurrentEnemyTarget.transform.position;
        Direction = targetPos - (Vector2)Gun.transform.position;
        Gun.transform.up = Direction;
        if (timer.Finished)
        {
            GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            timer.Run();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyMovement newEnemy = collision.GetComponent<EnemyMovement>();
            Enemies.Add(newEnemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyMovement enemy = collision.GetComponent<EnemyMovement>();
            if (Enemies.Contains(enemy))
            {
                Enemies.Remove(enemy);
            }
        }
    }
}
