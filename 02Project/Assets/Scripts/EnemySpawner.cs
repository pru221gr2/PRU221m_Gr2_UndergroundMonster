using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //[SerializeField]
    public List<GameObject> Enemies = new List<GameObject>();
    Timer timer;
    //[SerializeField]
    public Transform spawnPoint1;
    //[SerializeField]
    public Transform spawnPoint2;

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 4;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (timer.Finished)
            {
                int randomSpawnPoint = Random.Range(0, 2);
                switch (randomSpawnPoint)
                {
                    case 0:
                        var enemy1 = Instantiate(Enemies[0], spawnPoint1.position, Quaternion.identity);
                        var move1 = enemy1.GetComponent<EnemyMovement>();
                        move1.Waypoints = GameObject.Find("Waypoints").GetComponent<Waypoints>().Waypoints1;
                        break;
                    case 1:
                        var enemy2 = Instantiate(Enemies[0], spawnPoint2.position, Quaternion.identity);
                        var move2 = enemy2.GetComponent<EnemyMovement>();
                        move2.Waypoints = GameObject.Find("Waypoints").GetComponent<Waypoints>().Waypoints2;
                        break;
                }
                timer.Run();
            }
        }
        catch 
        {

        }
        
    }
}
