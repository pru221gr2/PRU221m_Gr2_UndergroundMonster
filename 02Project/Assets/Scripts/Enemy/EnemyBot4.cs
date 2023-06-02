public class EnemyBot4 : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Health = 10;
        Speed = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Init()
    {
        Health = 10;
        Speed = 1;
    }
}
