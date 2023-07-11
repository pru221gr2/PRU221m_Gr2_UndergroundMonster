using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Timer attackTimer;
    private float attackTimerDuration;
    [SerializeField]
    private Transform attackPoint;
    [SerializeField]
    private Enemy enemyScript;
    private bool firstHit = true;

    // Start is called before the first frame update
    void Start()
    {
        attackTimer = GetComponent<Timer>();
        attackTimerDuration = 1 / enemyScript.AttackSpeed;
        attackTimer.Duration = attackTimerDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyScript.IsAttacking)
        {
            //change animation
            enemyScript.Animator.SetBool("IsAttacking", true);

            //detect turret and damage it
            Collider2D[] collider2d = Physics2D.OverlapCircleAll(attackPoint.position, 2);
            foreach (Collider2D collider in collider2d)
            {
                if (collider != null && collider.GetComponent<Turret>() != null
                    && collider.gameObject.name.StartsWith("Turret"))
                {
                    if (firstHit)
                    {
                        collider.GetComponent<Turret>().TakeDamage(enemyScript.Damage);
                        firstHit = false;
                        attackTimer.Run();
                    }
                    else
                    {
                        if (attackTimer.Finished)
                        {
                            collider.GetComponent<Turret>().TakeDamage(enemyScript.Damage);
                            attackTimer.Run();
                        }
                    }
                }
            }
        }
    }
}
