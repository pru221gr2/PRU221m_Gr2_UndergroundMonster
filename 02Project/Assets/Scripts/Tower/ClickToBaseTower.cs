using Assets.Scripts.Tower;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickToBaseTower : MonoBehaviour
{
    [SerializeField]
    List<UnityEngine.Object> listTower;
    static Transform transformTower;
    public static List<BaseTowerBuild> baseTowerBuilds = new List<BaseTowerBuild>();
    public static BaseTowerBuild baseTowerBuildinteract = new BaseTowerBuild();
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
    public void OnMouseDown()
    {
        //add click audio
        AudioManager.Instance.PlaySFX("Select");
        transformTower = transform;
        baseTowerBuildinteract = baseTowerBuilds.FirstOrDefault(btb => btb.TransformBase.Equals(transformTower));
        if (baseTowerBuildinteract != null)
        {
            GameObject.FindGameObjectWithTag("TowerOptionUpdate").GetComponent<Canvas>().enabled = true;
            var moneyUpdate = GetMoneyTurretUpdate(baseTowerBuildinteract);
            var moneyRemove = GetMoneyTurretRemove(baseTowerBuildinteract);
            if (baseTowerBuildinteract.TurretLevel == 3)
            {
                GameObject.FindGameObjectWithTag("UpdateTowerButton").GetComponent<Button>().enabled = false;
                GameObject.FindGameObjectWithTag("PriceUpdateTower").GetComponent<TextMeshProUGUI>().enabled = false;
            }
            GameObject.FindGameObjectWithTag("PriceUpdateTower").GetComponent<TextMeshProUGUI>().text = moneyUpdate.ToString()+"$";
            GameObject.FindGameObjectWithTag("PriceRemoveTower").GetComponent<TextMeshProUGUI>().text = Math.Ceiling(moneyRemove * 0.8).ToString()+"$";
            //open option update tower red
            //open option update tower green

            //open option update tower blue

            
            //Update tower will be create in phase two
        }
        else
        {
            //buy tower
            GameObject.FindGameObjectWithTag("TowerOption").GetComponent<Canvas>().enabled = true;
        }

    }
    public void UpdateTurret()
    {
        var moneyUpdate = GetMoneyTurretUpdate(baseTowerBuildinteract);
        Debug.Log(moneyUpdate);
       if (Collect.countCoin >= moneyUpdate)
        {
            //build new turret
            AudioManager.Instance.PlaySFX("Build");
            Collect.countCoin -= moneyUpdate;
            RemoveTurret(baseTowerBuildinteract);
            GameObject turret = GameObject.Instantiate(listTower[GetLocationNextLevelInArray(baseTowerBuildinteract)], transformTower.position, Quaternion.identity) as GameObject;
            baseTowerBuilds.Add(new BaseTowerBuild()
            {
                TurretType = baseTowerBuildinteract.TurretType,
                TurretLevel = baseTowerBuildinteract.TurretLevel+1,
                TransformBase = transformTower,
                TransformTurret = turret.transform
            });
            GameObject.FindGameObjectWithTag("TowerOptionUpdate").GetComponent<Canvas>().enabled = false;
        }
        else
        {

        }
    }
    public void SellTurret()
    {
        var money = GetMoneyTurretRemove(baseTowerBuildinteract);
        Collect.countCoin += (int)Math.Ceiling(money * 0.8);
        RemoveTurret(baseTowerBuildinteract);
        GameObject.FindGameObjectWithTag("TowerOptionUpdate").GetComponent<Canvas>().enabled = false;

        //enabled update tower
        GameObject.FindGameObjectWithTag("UpdateTowerButton").GetComponent<Button>().enabled = true;
        GameObject.FindGameObjectWithTag("PriceUpdateTower").GetComponent<TextMeshProUGUI>().enabled = true;

    }
    public int GetLocationNextLevelInArray(BaseTowerBuild baseTowerBuild)
    {
        switch (baseTowerBuild.TurretType)
        {
            case TurretType.Red:
                switch (baseTowerBuild.TurretLevel)
                {
                    case 1:
                        return 3;
                        break;
                    case 2:
                        return 6;
                        break;
                }
                break;

            case TurretType.Green:
                switch (baseTowerBuild.TurretLevel)
                {
                    case 1:
                        return 4;
                        break;
                    case 2:
                        return 7;
                        break;
                }
                break;

            case TurretType.Blu:
                switch (baseTowerBuild.TurretLevel)
                {
                    case 1:
                        return 5;
                        break;
                    case 2:
                        return 8;
                        break;
                }
                break;
        }
        return -1;
    }
    public int GetMoneyTurretUpdate(BaseTowerBuild baseTowerBuild)
    {
        switch (baseTowerBuild.TurretType)
        {
            case TurretType.Red:
                switch (baseTowerBuild.TurretLevel)
                {
                    case 1:
                        return Collect.MoneyTurretOneLevelTwo;
                        break;
                    case 2:
                        return Collect.MoneyTurretOneLevelThree;
                        break;
                }
                break;

            case TurretType.Green:
                switch (baseTowerBuild.TurretLevel)
                {
                    case 1:
                        return Collect.MoneyTurretTwoLevelTwo;
                        break;
                    case 2:
                        return Collect.MoneyTurretTwoLevelThree;
                        break;
                }
                break;

            case TurretType.Blu:
                switch (baseTowerBuild.TurretLevel)
                {
                    case 1:
                        return Collect.MoneyTurretThreeLevelTwo;
                        break;
                    case 2:
                        return Collect.MoneyTurretThreeLevelThree;
                        break;
                }
                break;
        }
        return -1;
    }
    public int GetMoneyTurretRemove(BaseTowerBuild baseTowerBuild)
    {
        switch (baseTowerBuild.TurretType)
        {
            case TurretType.Red:
                switch (baseTowerBuild.TurretLevel)
                {
                    case 1:
                        return Collect.MoneyTurretOneLevelOne;
                        break;
                    case 2:
                        return Collect.MoneyTurretOneLevelTwo;
                        break;
                    case 3:
                        return Collect.MoneyTurretOneLevelThree;
                        break;
                }
                break;

            case TurretType.Green:
                switch (baseTowerBuild.TurretLevel)
                {
                    case 1:
                        return Collect.MoneyTurretTwoLevelOne;
                        break;
                    case 2:
                        return Collect.MoneyTurretTwoLevelTwo;
                        break;
                    case 3:
                        return Collect.MoneyTurretTwoLevelThree;
                        break;
                }
                break;

            case TurretType.Blu:
                switch (baseTowerBuild.TurretLevel)
                {
                    case 1:
                        return Collect.MoneyTurretThreeLevelOne;
                        break;
                    case 2:
                        return Collect.MoneyTurretThreeLevelTwo;
                        break;
                    case 3:
                        return Collect.MoneyTurretThreeLevelThree;
                        break;
                }
                break;
        }
        return -1;
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
    public void CloseButtonUpdate()
    {
        //add click audio
        AudioManager.Instance.PlaySFX("Select");
        GameObject.FindGameObjectWithTag("TowerOptionUpdate").GetComponent<Canvas>().enabled = false;
        //enable update tower button
        GameObject.FindGameObjectWithTag("UpdateTowerButton").GetComponent<Button>().enabled = true;
        GameObject.FindGameObjectWithTag("PriceUpdateTower").GetComponent<TextMeshProUGUI>().enabled = true;
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
                TurretLevel = 1,
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
                TurretType = TurretType.Blu,
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
