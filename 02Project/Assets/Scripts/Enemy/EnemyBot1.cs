using Assets.Scripts.FileManager;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBot1 : Enemy
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
            Health = keyValuePairs["Bot1"].Health;
            Speed = keyValuePairs["Bot1"].Speed;
            Damage = 0;
            AttackSpeed = 0;
        }
        else
        {
            Health = gameObject.GetComponent<EnemyBot1>().Health;
            Speed = gameObject.GetComponent<EnemyBot1>().Speed;
            Damage = gameObject.GetComponent<EnemyBot1>().Damage;
            AttackSpeed = gameObject.GetComponent<EnemyBot1>().AttackSpeed;
        }
    }
}
