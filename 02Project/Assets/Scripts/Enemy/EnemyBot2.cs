using UnityEngine;

public class EnemyBot2 : Enemy
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
            Health = 15;
            Speed = 0.5f;
            Damage = 0;
            AttackSpeed = 0;
        }
        else
        {
            Health = gameObject.GetComponent<EnemyBot2>().Health;
            Speed = gameObject.GetComponent<EnemyBot2>().Speed;
            Damage = gameObject.GetComponent<EnemyBot2>().Damage;
            AttackSpeed = gameObject.GetComponent<EnemyBot2>().AttackSpeed;
        }
    }
}
