using Assets.Scripts.FileManager;
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
            IDictionary<string, EnemyData> keyValuePairs = FileManager.Instance.ReadEnemyConfig();
            Health = keyValuePairs["Bot5"].Health;
            Speed = keyValuePairs["Bot5"].Speed;
            Damage = keyValuePairs["Bot5"].Damage;
            AttackSpeed = keyValuePairs["Bot5"].AttackSpeed;
        }
        else
        {
            Health = gameObject.GetComponent<EnemyBot5>().Health;
            Speed = gameObject.GetComponent<EnemyBot5>().Speed;
            Damage = gameObject.GetComponent<EnemyBot5>().Damage;
            AttackSpeed = gameObject.GetComponent<EnemyBot5>().AttackSpeed;
        }
    }
}
