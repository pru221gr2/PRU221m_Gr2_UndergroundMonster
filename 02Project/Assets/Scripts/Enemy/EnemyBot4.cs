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
        IDictionary<string, EnemyData> keyValuePairs = FileManager.Instance.ReadEnemyConfig();

        if (gameObject == null)
        {
            //Health = 10;
            //Speed = 1;
            Health = keyValuePairs["Bot4"].Health;
            Speed = keyValuePairs["Bot4"].Speed;
        }
        else
        {
            Health = gameObject.GetComponent<EnemyBot4>().Health;
            Speed = gameObject.GetComponent<EnemyBot4>().Speed;
        }
    }
}
