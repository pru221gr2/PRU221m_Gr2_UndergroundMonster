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
        IDictionary<string, EnemyData> keyValuePairs = FileManager.Instance.ReadEnemyConfig();
        if (gameObject == null)
        {
            //Health = 10;
            //Speed = 2;
            Health = keyValuePairs["Bot1"].Health;
            Speed = keyValuePairs["Bot1"].Speed;
        }
        else
        {
            Health = gameObject.GetComponent<EnemyBot1>().Health;
            Speed = gameObject.GetComponent<EnemyBot1>().Speed;
        }
    }
}
