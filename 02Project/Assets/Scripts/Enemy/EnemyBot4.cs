using Assets.Scripts.FileManager;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBot4 : Enemy
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
            Health = keyValuePairs["Bot4"].Health;
            Speed = keyValuePairs["Bot4"].Speed;
            Damage = keyValuePairs["Bot4"].Damage;
            AttackSpeed = keyValuePairs["Bot4"].AttackSpeed;
        }
        else
        {
            Health = gameObject.GetComponent<EnemyBot4>().Health;
            Speed = gameObject.GetComponent<EnemyBot4>().Speed;
            Damage = gameObject.GetComponent<EnemyBot4>().Damage;
            AttackSpeed = gameObject.GetComponent<EnemyBot4>().AttackSpeed;
        }
    }
}
