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
            Health = 30;
            Speed = 0.7f;
        }
        else
        {
            Health = gameObject.GetComponent<EnemyBot6>().Health;
            Speed = gameObject.GetComponent<EnemyBot6>().Speed;
        }
    }
}
