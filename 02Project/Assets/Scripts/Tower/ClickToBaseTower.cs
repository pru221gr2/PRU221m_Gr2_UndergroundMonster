using Assets.Scripts.Tower;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ClickToBaseTower : MonoBehaviour
{
    [SerializeField]
    List<Object> listTower;
    static Transform transformTower;
    static List<BaseTowerBuild> baseTowerBuilds = new List<BaseTowerBuild>();

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

        turrentOneLevelOne.text = Collect.MoneyTurretOneLevelOne + "$";
        turrentTwoLevelOne.text = Collect.MoneyTurretTwoLevelOne + "$";
        turrentThreeLevelOne.text = Collect.MoneyTurretThreeLevelOne + "$";
    }
    //when player click to base tower
    private void OnMouseDown()
    {
        //add click audio
        AudioManager.Instance.PlaySFX("Select");
        transformTower =transform;
        var gameObject = baseTowerBuilds.FirstOrDefault(btb => btb.TransformBase.Equals(transformTower));
        if (gameObject!=null)
        {
            //open option update tower red

            //open option update tower green

            //open option update tower blue

            RemoveTurret(gameObject);
            //Update tower will be create in phase two
        }
        else
        {
            //Buy tower
            GameObject.FindGameObjectWithTag("TowerOption").GetComponent<Canvas>().enabled = true;
        }

    }
    public void RemoveTurret(BaseTowerBuild baseTowerBuild)
    {
        baseTowerBuilds.Remove(baseTowerBuild);
        Destroy(baseTowerBuild.TransformTurret.gameObject);
    }
    //when player click to close option tower
    public void CloseButton()
    {
        //add click audio
        AudioManager.Instance.PlaySFX("Select");
        GameObject.FindGameObjectWithTag("TowerOption").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("PriceOfTower1Level1").GetComponent<TextMeshProUGUI>().color = Color.black;
        GameObject.FindGameObjectWithTag("PriceOfTower2Level1").GetComponent<TextMeshProUGUI>().color = Color.black;
        GameObject.FindGameObjectWithTag("PriceOfTower3Level1").GetComponent<TextMeshProUGUI>().color = Color.black;
    }
    //When player chosse Tower 1
    public void ClickTowerButtonOne()
    {
        GameObject.FindGameObjectWithTag("PriceOfTower1Level1").GetComponent<TextMeshProUGUI>().color = Color.black;
        //add build audio
        if (Collect.countCoin >= Collect.MoneyTurretOneLevelOne)
        {
            AudioManager.Instance.PlaySFX("Build");
            Collect.countCoin -= Collect.MoneyTurretOneLevelOne;

            GameObject turret = GameObject.Instantiate(listTower[0], transformTower.position, Quaternion.identity) as GameObject;
            baseTowerBuilds.Add(new BaseTowerBuild()
            {
                TurretType = TurretType.Red,
                TurretLevel =1,
                TransformBase = transformTower,
                TransformTurret = turret.transform
            });
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
        if (Collect.countCoin >= Collect.MoneyTurretTwoLevelOne)
        {
            //add build audio
            AudioManager.Instance.PlaySFX("Build");
            Collect.countCoin -= Collect.MoneyTurretTwoLevelOne;

            GameObject turret = GameObject.Instantiate(listTower[1], transformTower.position, Quaternion.identity) as GameObject;
            baseTowerBuilds.Add(new BaseTowerBuild()
            {
                TurretType = TurretType.Green,
                TurretLevel = 1,
                TransformBase = transformTower,
                TransformTurret = turret.transform
            });
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
        if (Collect.countCoin >= Collect.MoneyTurretThreeLevelOne)
        {
            AudioManager.Instance.PlaySFX("Build");
            Collect.countCoin -= Collect.MoneyTurretThreeLevelOne;
            GameObject turret = GameObject.Instantiate(listTower[2], transformTower.position, Quaternion.identity) as GameObject;
            baseTowerBuilds.Add(new BaseTowerBuild()
            {
                TurretType = TurretType.Red,
                TurretLevel = 1,
                TransformBase = transformTower,
                TransformTurret = turret.transform
            });
            GameObject.FindGameObjectWithTag("TowerOption").GetComponent<Canvas>().enabled = false;
        }
        else
        {
            GameObject.FindGameObjectWithTag("PriceOfTower3Level1").GetComponent<TextMeshProUGUI>().color = Color.red;
        }
    }
}
