using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //khi co script projectile chuan se tru mau theo dame projectile
        if (collision.gameObject.name.ToLower().Contains("projectile"))
        {
            if (gameObject.name.Contains("Bot1"))
            {
                gameObject.GetComponent<EnemyBot1>().Health -= 10;
                if (gameObject.GetComponent<EnemyBot1>().Health <= 0)
                {
                    gameObject.GetComponent<EnemyBot1>().Animator.SetBool("IsAlive", false);
                    Destroy(gameObject, 1.2f);
                }
            }
            if (gameObject.name.Contains("Bot2"))
            {
                gameObject.GetComponent<EnemyBot2>().Health -= 10;
                if (gameObject.GetComponent<EnemyBot2>().Health <= 0)
                {
                    gameObject.GetComponent<EnemyBot2>().Animator.SetBool("IsAlive", false);
                    Destroy(gameObject, 1.2f);
                }
            }
            if (gameObject.name.Contains("Bot3"))
            {
                gameObject.GetComponent<EnemyBot3>().Health -= 10;
                if (gameObject.GetComponent<EnemyBot3>().Health <= 0)
                {
                    gameObject.GetComponent<EnemyBot3>().Animator.SetBool("IsAlive", false);
                    Destroy(gameObject, 1.2f);
                }
            }
            if (gameObject.name.Contains("Bot4"))
            {
                gameObject.GetComponent<EnemyBot4>().Health -= 10;
                if (gameObject.GetComponent<EnemyBot4>().Health <= 0)
                {
                    gameObject.GetComponent<EnemyBot4>().Animator.SetBool("IsAlive", false);
                    Destroy(gameObject, 1.2f);
                }
            }
            if (gameObject.name.Contains("Bot5"))
            {
                gameObject.GetComponent<EnemyBot5>().Health -= 10;
                if (gameObject.GetComponent<EnemyBot5>().Health <= 0)
                {
                    gameObject.GetComponent<EnemyBot5>().Animator.SetBool("IsAlive", false);
                    Destroy(gameObject, 1.2f);
                }
            }
            if (gameObject.name.Contains("Bot6"))
            {
                gameObject.GetComponent<EnemyBot6>().Health -= 10;
                if (gameObject.GetComponent<EnemyBot6>().Health <= 0)
                {
                    gameObject.GetComponent<EnemyBot6>().Animator.SetBool("IsAlive", false);
                    Destroy(gameObject, 1.2f);
                }
            }
        }
    }
}
