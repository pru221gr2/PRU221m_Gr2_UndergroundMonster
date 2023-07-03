using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanTurret : MonoBehaviour
{
    private GameObject enemy;
    private GameObject turret;
    [SerializeField]
    private Enemy enemyScript;
    void Start()
    {
        enemy = gameObject.transform.parent.gameObject;
    }

    private void Update()
    {
        if (turret != null)
        {
            var turretPosition = turret.transform.position;
            var target = new Vector2(turretPosition.x - 2f, turretPosition.y);

            //if enemy has reached the turret then attack it, else keep going to the turret
            if ((Vector2)enemy.transform.position != target)
            {
                enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, target,
                                enemyScript.Speed * Time.deltaTime);
            }
            else
            {
                enemyScript.IsAttacking = true;
            }
        }
        else
        {
            enemyScript.IsAttacking = false;
            enemyScript.Animator.SetBool("IsAttacking", false);
            enemy.GetComponent<EnemyMovement>().IsMovingToTurret = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Turret"))
        {
            enemy.GetComponent<EnemyMovement>().IsMovingToTurret = true;
            turret = collision.gameObject;
        }
    }
}
