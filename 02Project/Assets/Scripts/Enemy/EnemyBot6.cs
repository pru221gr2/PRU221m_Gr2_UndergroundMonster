using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBot6 : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Init(GameObject gameObject)
    {
        if (gameObject == null)
        {
            Health = 5;
            Speed = 0.7f;
            Damage = 3;
            AttackSpeed = 0.75f;
        }
        else
        {
            Health = gameObject.GetComponent<EnemyBot6>().Health;
            Speed = gameObject.GetComponent<EnemyBot6>().Speed;
            Damage = gameObject.GetComponent<EnemyBot6>().Damage;
            AttackSpeed = gameObject.GetComponent<EnemyBot6>().AttackSpeed;
        }
    }
}
