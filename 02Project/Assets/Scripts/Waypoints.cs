using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to store waypoints only
/// </summary>
public class Waypoints : MonoBehaviour
{
    List<Transform> waypoints1 = new List<Transform>();
    List<Transform> waypoints2 = new List<Transform>();

    public List<Transform> Waypoints1 { get { return waypoints1; } }
    public List<Transform> Waypoints2 { get { return waypoints2; } }
    private void Awake()
    {
        AddWaypoints1();
        AddWaypoints2();
    }

    public void AddWaypoints1()
    {
        waypoints1.Add(GameObject.Find("Waypoint1").transform);
        waypoints1.Add(GameObject.Find("Waypoint4").transform);
        waypoints1.Add(GameObject.Find("Waypoint5").transform);
        waypoints1.Add(GameObject.Find("Waypoint6").transform);
        waypoints1.Add(GameObject.Find("Waypoint7").transform);
        waypoints1.Add(GameObject.Find("Waypoint8").transform);
        waypoints1.Add(GameObject.Find("Waypoint9").transform);
        waypoints1.Add(GameObject.Find("Waypoint10").transform);
        waypoints1.Add(GameObject.Find("Waypoint11").transform);
        waypoints1.Add(GameObject.Find("Waypoint12").transform);
        waypoints1.Add(GameObject.Find("Waypoint13").transform);
        waypoints1.Add(GameObject.Find("Waypoint14").transform);
    }
    public void AddWaypoints2()
    {
        waypoints2.Add(GameObject.Find("Waypoint2").transform);
        waypoints2.Add(GameObject.Find("Waypoint3").transform);
        waypoints2.Add(GameObject.Find("Waypoint5").transform);
        waypoints2.Add(GameObject.Find("Waypoint6").transform);
        waypoints2.Add(GameObject.Find("Waypoint7").transform);
        waypoints2.Add(GameObject.Find("Waypoint8").transform);
        waypoints2.Add(GameObject.Find("Waypoint9").transform);
        waypoints2.Add(GameObject.Find("Waypoint10").transform);
        waypoints2.Add(GameObject.Find("Waypoint11").transform);
        waypoints2.Add(GameObject.Find("Waypoint12").transform);
        waypoints2.Add(GameObject.Find("Waypoint13").transform);
        waypoints2.Add(GameObject.Find("Waypoint14").transform);
    }
}
