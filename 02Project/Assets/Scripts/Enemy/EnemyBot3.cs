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
            Health = 30;
            Speed = 0.7f;
        }
        else
        {
            Health = gameObject.GetComponent<EnemyBot3>().Health;
            Speed = gameObject.GetComponent<EnemyBot3>().Speed;
        }
    }
}
