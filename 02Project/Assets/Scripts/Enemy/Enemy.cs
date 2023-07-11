using System;
using TMPro;
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
            if (gameObject.name.StartsWith("Bot1")) Collect.countCoin += 20;
            if (gameObject.name.StartsWith("Bot2")) Collect.countCoin += 50;
            if (gameObject.name.StartsWith("Bot3")) Collect.countCoin += 40;
            if (gameObject.name.StartsWith("Bot4")) Collect.countCoin += 40;
            if (gameObject.name.StartsWith("Bot5")) Collect.countCoin += 40;
            if (gameObject.name.StartsWith("Bot6")) Collect.countCoin += 60;
            Collect.countTrophy += UnityEngine.Random.Range(10, 20);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EndPoint")
        {
            Die();
            HealthBarBase.Instance.currentHealth -= 1;
            HealthBarBase.Instance.healthBar.fillAmount = HealthBarBase.Instance.currentHealth / HealthBarBase.Instance.maxHealth;
            if (HealthBarBase.Instance.currentHealth <= 0)
            {
                var canvas = GameObject.Find("CanvasLose").GetComponent<Canvas>();
                GameObject.Find("LostText").GetComponent<TextMeshProUGUI>().text = $"Score: {Collect.countTrophy}";
                canvas.GetComponent<Canvas>().enabled = true;
                Time.timeScale = 0;
            }
        }
    }

    public void Die()
    {
        Animator.SetBool("IsAlive", false);
        Destroy(gameObject, 0.5f);
    }
}
