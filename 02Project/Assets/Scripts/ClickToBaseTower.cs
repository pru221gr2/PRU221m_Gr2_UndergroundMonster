using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToBaseTower : MonoBehaviour
{
    [SerializeField]
    List<Object> listTower;
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
        Instantiate(listTower[0], transformTower.position, Quaternion.identity);
        GameObject.FindGameObjectWithTag("TowerOption").GetComponent<Canvas>().enabled = false;
    }
    //When player chosse Tower 2
    public void ClickTowerButtonTwo()
    {
        listTransformTowerUsed.Add(transformTower);
        Instantiate(listTower[1], transformTower.position, Quaternion.identity);
        GameObject.FindGameObjectWithTag("TowerOption").GetComponent<Canvas>().enabled = false;
    }
    //When player chosse Tower 3
    public void ClickTowerButtonThree()
    {
        listTransformTowerUsed.Add(transformTower);
        Instantiate(listTower[2], transformTower.position, Quaternion.identity);
        GameObject.FindGameObjectWithTag("TowerOption").GetComponent<Canvas>().enabled = false;
    }
}
