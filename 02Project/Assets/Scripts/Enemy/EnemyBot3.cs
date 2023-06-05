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
        IDictionary<string, EnemyData> keyValuePairs = FileManager.Instance.ReadEnemyConfig();

        if (gameObject == null)
        {
            //Health = 30;
            //Speed = 0.7f;
            Health = keyValuePairs["Bot3"].Health;
            Speed = keyValuePairs["Bot3"].Speed;
        }
        else
        {
            Health = gameObject.GetComponent<EnemyBot3>().Health;
            Speed = gameObject.GetComponent<EnemyBot3>().Speed;
        }
    }
}
