using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBot2 : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Health = 50;
        Speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Init()
    {
        Health = 50;
        Speed = 0.5f;
    }
}
