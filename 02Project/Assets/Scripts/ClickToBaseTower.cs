using System.Collections.Generic;
using UnityEngine;

public class ClickToBaseTower : MonoBehaviour
{
    [SerializeField]
    List<Object> listTower;
    [SerializeField]
    Object baseTower;
    static Transform transformTower;
    static List<Transform> listTransformTowerUsed = new List<Transform>();
    //when player click to base tower
    private void OnMouseDown()
    {
        transformTower = transform;
        if (listTransformTowerUsed.Contains(transformTower))
        {
            //Update tower
        }
        else
        {
            //Buy tower
            GameObject.FindGameObjectWithTag("TowerOption").GetComponent<Canvas>().enabled = true;
        }
        Debug.Log("ss");
    }
    //when player click to close option tower
    public void CloseButton()
    {
        GameObject.FindGameObjectWithTag("TowerOption").GetComponent<Canvas>().enabled = false;
    }
    //When player chosse Tower 1
    public void ClickTowerButtonOne()
    {
        listTransformTowerUsed.Add(transformTower);
        Instantiate(baseTower, transformTower.position, Quaternion.identity);
        Instantiate(listTower[0], new Vector3(transformTower.position.x, transformTower.position.y + 0.5f, transformTower.position.z), Quaternion.identity);
        GameObject.FindGameObjectWithTag("TowerOption").GetComponent<Canvas>().enabled = false;
    }
    //When player chosse Tower 2
    public void ClickTowerButtonTwo()
    {
        listTransformTowerUsed.Add(transformTower);
        Instantiate(baseTower, transformTower.position, Quaternion.identity);
        Instantiate(listTower[1], new Vector3(transformTower.position.x - 0.2f, transformTower.position.y + 0.9f, transformTower.position.z), Quaternion.identity);
        GameObject.FindGameObjectWithTag("TowerOption").GetComponent<Canvas>().enabled = false;
    }
    //When player chosse Tower 3
    public void ClickTowerButtonThree()
    {
        listTransformTowerUsed.Add(transformTower);
        Instantiate(baseTower, transformTower.position, Quaternion.identity);
        Instantiate(listTower[2], new Vector3(transformTower.position.x, transformTower.position.y + 0.71f, transformTower.position.z), Quaternion.identity);
        GameObject.FindGameObjectWithTag("TowerOption").GetComponent<Canvas>().enabled = false;
    }
}
