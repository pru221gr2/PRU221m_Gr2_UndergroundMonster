using System;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    internal float MaxHealth;
    public float Health { get; set; }
    public float Speed { get; set; }
    public float Damage { get; set; }
    public Animator Animator { get; set; }
    public float AttackSpeed { get; set; }
    public bool IsAttacking { get; set; } = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Animator = GetComponent<Animator>();
        MaxHealth = Health;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public virtual void Init(GameObject gameObject)
    {

    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
            Collect.countCoin += 10;
            Collect.countTrophy += UnityEngine.Random.Range(10, 20);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EndPoint")
        {
            Die();
            HealthBarBase.Instance.currentHealth -= Damage;
            HealthBarBase.Instance.healthBar.fillAmount = HealthBarBase.Instance.currentHealth / HealthBarBase.Instance.maxHealth;
        }
    }

    public void Die()
    {
        Animator.SetBool("IsAlive", false);
        Destroy(gameObject, 0.5f);
    }
}
