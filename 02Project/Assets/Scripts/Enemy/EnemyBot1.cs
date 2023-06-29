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
        if (gameObject == null)
        {
            Health = 2;
            Speed = 2f;
            Damage = 10;
        }
        else
        {
            Health = gameObject.GetComponent<EnemyBot1>().Health;
            Speed = gameObject.GetComponent<EnemyBot1>().Speed;
            Damage = gameObject.GetComponent<EnemyBot1>().Damage;
        }
    }
}
