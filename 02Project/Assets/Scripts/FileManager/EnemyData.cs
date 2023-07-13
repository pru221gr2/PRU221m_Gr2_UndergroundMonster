namespace Assets.Scripts.FileManager
{
    public class EnemyData
    {
        public float Health { get; set; }
        public float Speed { get; set; }
        public float Damage { get; set; }
        public float AttackSpeed { get; set; }

        public EnemyData(float health, float speed, float damage, float attackSpeed)
        {
            Health = health;
            Speed = speed;
            Damage = damage;
            AttackSpeed = attackSpeed;
        }
    }
}
