using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBot5 : Enemy
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
            Health = 4;
            Speed = 0.7f;
            Damage = 15;
        }
        else
        {
            Health = gameObject.GetComponent<EnemyBot5>().Health;
            Speed = gameObject.GetComponent<EnemyBot5>().Speed;
            Damage = gameObject.GetComponent<EnemyBot5>().Damage;
        }
    }
}
