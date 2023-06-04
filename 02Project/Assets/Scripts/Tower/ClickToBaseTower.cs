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
        //add click audio
        AudioManager.Instance.PlaySFX("Select");
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
        //add click audio
        AudioManager.Instance.PlaySFX("Select");
        GameObject.FindGameObjectWithTag("TowerOption").GetComponent<Canvas>().enabled = false;
    }
    //When player chosse Tower 1
    public void ClickTowerButtonOne()
    {
        //add build audio
        AudioManager.Instance.PlaySFX("Build");
        
        listTransformTowerUsed.Add(transformTower);
        Instantiate(listTower[0], transformTower.position, Quaternion.identity);
        GameObject.FindGameObjectWithTag("TowerOption").GetComponent<Canvas>().enabled = false;
    }
    //When player chosse Tower 2
    public void ClickTowerButtonTwo()
    {
        //add build audio
        AudioManager.Instance.PlaySFX("Build");

        listTransformTowerUsed.Add(transformTower);
        Instantiate(listTower[1], transformTower.position, Quaternion.identity);
        GameObject.FindGameObjectWithTag("TowerOption").GetComponent<Canvas>().enabled = false;
    }
    //When player chosse Tower 3
    public void ClickTowerButtonThree()
    {
        //add build audio
        AudioManager.Instance.PlaySFX("Build");

        listTransformTowerUsed.Add(transformTower);
        Instantiate(listTower[2], transformTower.position, Quaternion.identity);
        GameObject.FindGameObjectWithTag("TowerOption").GetComponent<Canvas>().enabled = false;
    }
}
