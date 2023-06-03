using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{

    public Transform[] waypoints;
    public float moveSpeed = 5f;

    private int currentWaypointIndex = 0;

    void Start()
    {

    }

    void Update()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            MoveTowardsWaypoint();
        }
        else
        {
            EnemyReachedEnd();
        }
    }

    private void MoveTowardsWaypoint()
    {
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 moveDirection = (targetWaypoint.position - transform.position).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++;
        }
    }

    private void EnemyReachedEnd()
    {
        Destroy(gameObject);
    }
}
