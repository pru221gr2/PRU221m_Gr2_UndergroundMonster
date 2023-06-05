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
        if (gameObject == null)
        {
            Health = 10;
            Speed = 1;
            Damage = 10;
        }
        else
        {
            Health = gameObject.GetComponent<EnemyBot4>().Health;
            Speed = gameObject.GetComponent<EnemyBot4>().Speed;
            Damage = gameObject.GetComponent<EnemyBot4>().Damage;
        }
    }
}
