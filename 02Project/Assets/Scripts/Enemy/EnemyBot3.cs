using Assets.Scripts.FileManager;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBot3 : Enemy
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
            Health = keyValuePairs["Bot3"].Health;
            Speed = keyValuePairs["Bot3"].Speed;
            Damage = keyValuePairs["Bot3"].Damage;
            AttackSpeed = keyValuePairs["Bot3"].AttackSpeed;
        }
        else
        {
            Health = gameObject.GetComponent<EnemyBot3>().Health;
            Speed = gameObject.GetComponent<EnemyBot3>().Speed;
            Damage = gameObject.GetComponent<EnemyBot3>().Damage;
            AttackSpeed = gameObject.GetComponent<EnemyBot3>().AttackSpeed;
        }
    }
}
