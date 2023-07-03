using Assets.Scripts.Enemy;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private Enemy enemy;
    float movementSpeed;
    int waypointIndex = 0;
    public List<Transform> Waypoints { get; set; }
    public bool IsMovingToTurret { get; set; } = false;
 
    // Start is called before the first frame update
    void Start()
    {
        EnemiesCounter.enemiesCount.Add(this.gameObject);
        SetMovementSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (!enemy.IsAttacking && !IsMovingToTurret)
        {
            transform.position = Vector2.MoveTowards(transform.position, Waypoints[waypointIndex].position, movementSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, Waypoints[waypointIndex].position) < 0.1f)
            {
                if (waypointIndex < Waypoints.Count - 1)
                {
                    waypointIndex++;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }  
    }

    void SetMovementSpeed()
    {
        if (gameObject.name.Contains("Bot1"))
            movementSpeed = gameObject.GetComponent<EnemyBot1>().Speed;
        if (gameObject.name.Contains("Bot2"))
            movementSpeed = gameObject.GetComponent<EnemyBot2>().Speed;
        if (gameObject.name.Contains("Bot3"))
            movementSpeed = gameObject.GetComponent<EnemyBot3>().Speed;
        if (gameObject.name.Contains("Bot4"))
            movementSpeed = gameObject.GetComponent<EnemyBot4>().Speed;
        if (gameObject.name.Contains("Bot5"))
            movementSpeed = gameObject.GetComponent<EnemyBot5>().Speed;
        if (gameObject.name.Contains("Bot6"))
            movementSpeed = gameObject.GetComponent<EnemyBot6>().Speed;
    }
}
