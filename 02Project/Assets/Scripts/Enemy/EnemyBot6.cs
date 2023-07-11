using Assets.Scripts.FileManager;
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
            IDictionary<string, EnemyData> keyValuePairs = FileManager.Instance.ReadEnemyConfig();
            Health = keyValuePairs["Bot6"].Health;
            Speed = keyValuePairs["Bot6"].Speed;
            Damage = keyValuePairs["Bot6"].Damage;
            AttackSpeed = keyValuePairs["Bot6"].AttackSpeed;
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
