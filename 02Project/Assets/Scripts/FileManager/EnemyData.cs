namespace Assets.Scripts.FileManager
{
    public class EnemyData
    {
        public float Health { get; set; }
        public float Speed { get; set; }

        public EnemyData(float health, float speed)
        {
            Health = health;
            Speed = speed;
        }
    }
}
