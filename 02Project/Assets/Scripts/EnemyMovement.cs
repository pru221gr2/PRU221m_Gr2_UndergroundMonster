using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed ;
    public List<Transform> Waypoints { get; set; }

    int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
