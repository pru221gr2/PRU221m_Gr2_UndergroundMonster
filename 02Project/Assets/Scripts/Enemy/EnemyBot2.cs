using Assets.Scripts.FileManager;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBot2 : Enemy
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
            Health = keyValuePairs["Bot2"].Health;
            Speed = keyValuePairs["Bot2"].Speed;
            Damage = 0;
            AttackSpeed = 0;
        }
        else
        {
            Health = gameObject.GetComponent<EnemyBot2>().Health;
            Speed = gameObject.GetComponent<EnemyBot2>().Speed;
            Damage = gameObject.GetComponent<EnemyBot2>().Damage;
            AttackSpeed = gameObject.GetComponent<EnemyBot2>().AttackSpeed;
        }
    }
}
