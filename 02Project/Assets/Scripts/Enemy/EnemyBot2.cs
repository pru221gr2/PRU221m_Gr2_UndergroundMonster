using UnityEngine;

public class EnemyBot2 : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        print(Health);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Init(GameObject gameObject)
    {
        if (gameObject == null)
        {
            Health = 50;
            Speed = 0.5f;
        }
        else
        {
            Health = gameObject.GetComponent<EnemyBot2>().Health;
            Speed = gameObject.GetComponent<EnemyBot2>().Speed;
        }
    }
}
