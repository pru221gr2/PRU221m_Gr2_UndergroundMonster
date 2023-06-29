using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickToBaseTower : MonoBehaviour
{
    [SerializeField]
    List<Object> listTower;
    static Transform transformTower;
    static List<Transform> listTransformTowerUsed = new List<Transform>();
    TextMeshProUGUI turrentOneLevelOne;
    TextMeshProUGUI turrentOneLevelTwo;
    TextMeshProUGUI turrentOneLevelThree;

    TextMeshProUGUI turrentTwoLevelOne;
    TextMeshProUGUI turrentTwoLevelTwo;
    TextMeshProUGUI turrentTwoLevelThree;

    TextMeshProUGUI turrentThreeLevelOne;
    TextMeshProUGUI turrentThreeLevelTwo;
    TextMeshProUGUI turrentThreeLevelThree;

    Canvas towerOption;
    private void Start()
    {
        turrentOneLevelOne = GameObject.FindGameObjectWithTag("PriceOfTower1Level1").GetComponent<TextMeshProUGUI>();
        //turrentOneLevelTwo = GameObject.FindGameObjectWithTag("PriceOfTower1Level2").GetComponent<TextMeshProUGUI>();
        //turrentOneLevelThree = GameObject.FindGameObjectWithTag("PriceOfTower1Level3").GetComponent<TextMeshProUGUI>();

        turrentTwoLevelOne = GameObject.FindGameObjectWithTag("PriceOfTower2Level1").GetComponent<TextMeshProUGUI>();
        //turrentTwoLevelTwo = GameObject.FindGameObjectWithTag("PriceOfTower2Level2").GetComponent<TextMeshProUGUI>();
        //turrentTwoLevelThree = GameObject.FindGameObjectWithTag("PriceOfTower2Level3").GetComponent<TextMeshProUGUI>();

        turrentThreeLevelOne = GameObject.FindGameObjectWithTag("PriceOfTower3Level1").GetComponent<TextMeshProUGUI>();
        //turrentThreeLevelTwo = GameObject.FindGameObjectWithTag("PriceOfTower3Level2").GetComponent<TextMeshProUGUI>();
        //turrentThreeLevelThree = GameObject.FindGameObjectWithTag("PriceOfTower3Level3").GetComponent<TextMeshProUGUI>();

        turrentOneLevelOne.text = Collect.MoneyTurretOneLevelOne+"$";
        turrentTwoLevelOne.text = Collect.MoneyTurretTwoLevelOne+"$";
        turrentThreeLevelOne.text = Collect.MoneyTurretThreeLevelOne+"$";
    }
    //when player click to base tower
    private void OnMouseDown()
    {
        //add click audio
        AudioManager.Instance.PlaySFX("Select");
        transformTower = transform;
        if (listTransformTowerUsed.Contains(transformTower))
        {
            //Update tower will be create in phase two
            Debug.Log("con cec");
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
        GameObject.FindGameObjectWithTag("PriceOfTower1Level1").GetComponent<TextMeshProUGUI>().color = Color.black;
        //add build audio
        if (Collect.countCoin > Collect.MoneyTurretOneLevelOne)
        {
        AudioManager.Instance.PlaySFX("Build");
        Collect.countCoin-=Collect.MoneyTurretOneLevelOne;
        listTransformTowerUsed.Add(transformTower);
        Instantiate(listTower[0], transformTower.position, Quaternion.identity);
            GameObject.FindGameObjectWithTag("TowerOption").GetComponent<Canvas>().enabled = false;
        }
        else
        {
            GameObject.FindGameObjectWithTag("PriceOfTower1Level1").GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        
    }
    //When player chosse Tower 2
    public void ClickTowerButtonTwo()
    {
        GameObject.FindGameObjectWithTag("PriceOfTower2Level1").GetComponent<TextMeshProUGUI>().color = Color.black;
        //add build audio
        if (Collect.countCoin > Collect.MoneyTurretTwoLevelOne)
        {
            //add build audio
            AudioManager.Instance.PlaySFX("Build");
            Collect.countCoin -= Collect.MoneyTurretTwoLevelOne;
            listTransformTowerUsed.Add(transformTower);
            Instantiate(listTower[1], transformTower.position, Quaternion.identity);
            GameObject.FindGameObjectWithTag("TowerOption").GetComponent<Canvas>().enabled = false;
        }
        else
        {
            GameObject.FindGameObjectWithTag("PriceOfTower2Level1").GetComponent<TextMeshProUGUI>().color = Color.red;
        }
    }
    //When player chosse Tower 3
    public void ClickTowerButtonThree()
    {
        GameObject.FindGameObjectWithTag("PriceOfTower3Level1").GetComponent<TextMeshProUGUI>().color = Color.black;
        //add build audio
        if (Collect.countCoin > Collect.MoneyTurretThreeLevelOne)
        {
            AudioManager.Instance.PlaySFX("Build");
            Collect.countCoin -= Collect.MoneyTurretThreeLevelOne;
            listTransformTowerUsed.Add(transformTower);
            Instantiate(listTower[2], transformTower.position, Quaternion.identity);
            GameObject.FindGameObjectWithTag("TowerOption").GetComponent<Canvas>().enabled = false;

        }
        else
        {
            GameObject.FindGameObjectWithTag("PriceOfTower3Level1").GetComponent<TextMeshProUGUI>().color = Color.red;
        }
    }
}
