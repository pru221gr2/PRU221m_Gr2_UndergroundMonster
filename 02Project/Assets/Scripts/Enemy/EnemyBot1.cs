using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBot1 : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Health = 10;
        Speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Init()
    {
        Health = 10;
        Speed = 2;
    }
}
