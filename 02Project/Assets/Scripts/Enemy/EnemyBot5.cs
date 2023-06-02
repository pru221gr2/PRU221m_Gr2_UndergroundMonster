using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBot5 : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Health = 30;
        Speed = 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Init()
    {
        Health = 30;
        Speed = 0.7f;
    }
}
