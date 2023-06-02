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
            Health = 10;
            Speed = 2;
        }
        else
        {
            Health = gameObject.GetComponent<EnemyBot1>().Health;
            Speed = gameObject.GetComponent<EnemyBot1>().Speed;
        }
    }
}
