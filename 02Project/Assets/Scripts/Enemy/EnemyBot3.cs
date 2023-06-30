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
        if (gameObject == null)
        {
            Health = 5;
            Speed = 0.7f;
            Damage = 10;
        }
        else
        {
            Health = gameObject.GetComponent<EnemyBot3>().Health;
            Speed = gameObject.GetComponent<EnemyBot3>().Speed;
            Damage = gameObject.GetComponent<EnemyBot3>().Damage;
        }
    }
}
