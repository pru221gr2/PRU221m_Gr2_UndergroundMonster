using Assets.Scripts.Tower;
using Assets.Scripts.Turret;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class ClickToBaseTower : MonoBehaviour
{
    private ProjectileSpawner _projectileSpawner;
    private EnemyScanner _enemyScanner;
    private float previousRange;
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

        turrentOneLevelOne.text = Collect.MoneyTurretOneLevelOne.ToString();
        turrentTwoLevelOne.text = Collect.MoneyTurretTwoLevelOne.ToString();
        turrentThreeLevelOne.text = Collect.MoneyTurretThreeLevelOne.ToString();
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
            GameObject.FindGameObjectWithTag("PriceUpdateTower").GetComponent<TextMeshProUGUI>().text = moneyUpdate.ToString();
            GameObject.FindGameObjectWithTag("PriceUpdateRange").GetComponent<TextMeshProUGUI>().text = Collect.MoneyUpdateRange.ToString();
            GameObject.FindGameObjectWithTag("PriceUpdateSpeed").GetComponent<TextMeshProUGUI>().text = Collect.MoneyUpdateSpeed.ToString();
            GameObject.FindGameObjectWithTag("PriceRemoveTower").GetComponent<TextMeshProUGUI>().text = Math.Ceiling(moneyRemove * 0.8).ToString();
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
        previousRange = GameObject.FindGameObjectsWithTag("Scanners").FirstOrDefault(sc => sc.transform.position.Equals(transformTower.position)).GetComponent<EnemyScanner>().range;
        Debug.Log(moneyUpdate);
       if (Collect.countCoin >= moneyUpdate)
        {
            //build new turret
            AudioManager.Instance.PlaySFX("Build");
            Collect.countCoin -= moneyUpdate;
            RemoveTurret(baseTowerBuildinteract);
            GameObject turret = GameObject.Instantiate(listTower[GetLocationNextLevelInArray(baseTowerBuildinteract)], transformTower.position, Quaternion.identity) as GameObject;
            _enemyScanner = GameObject.FindGameObjectsWithTag("Scanners").LastOrDefault(sc => sc.transform.position.Equals(transformTower.position)).GetComponent<EnemyScanner>();
            _enemyScanner.range = previousRange;
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

    public void UpdateTurretRange()
    {
        var moneyUpdateRange = Collect.MoneyUpdateRange;
        Debug.Log(moneyUpdateRange);
        if (Collect.countCoin >= moneyUpdateRange)
        {
            //update range attack
            AudioManager.Instance.PlaySFX("Build");
            Collect.countCoin -= moneyUpdateRange;
            _enemyScanner = GameObject.FindGameObjectsWithTag("Scanners").FirstOrDefault(sc => sc.transform.position.Equals(transformTower.position)).GetComponent<EnemyScanner>();
            _enemyScanner.range += 1f;
            GameObject.FindGameObjectWithTag("TowerOptionUpdate").GetComponent<Canvas>().enabled = false;
        }
        else
        {
            Debug.Log("con cec");
        }
    }

    public void UpdateTurretFireRate()
    {
        var moneyUpdateFireRate = Collect.MoneyUpdateSpeed;
        Debug.Log(moneyUpdateFireRate);
        if (Collect.countCoin >= moneyUpdateFireRate)
        {
            //update turret fire rate
            AudioManager.Instance.PlaySFX("Build");
            Collect.countCoin -= moneyUpdateFireRate;
            _projectileSpawner = GameObject.FindGameObjectsWithTag("Turret").FirstOrDefault(sc => sc.transform.position.Equals(transformTower.position)).GetComponent<ProjectileSpawner>();
            _projectileSpawner.FireRate -= 0.1f;
            GameObject.FindGameObjectWithTag("TowerOptionUpdate").GetComponent<Canvas>().enabled = false;
        }
        else
        {
            Debug.Log("con cec");
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
                    case 2:
                        return 6;
                }
                break;

            case TurretType.Green:
                switch (baseTowerBuild.TurretLevel)
                {
                    case 1:
                        return 4;
                    case 2:
                        return 7;
                }
                break;

            case TurretType.Blu:
                switch (baseTowerBuild.TurretLevel)
                {
                    case 1:
                        return 5;
                    case 2:
                        return 8;                }
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
                    case 2:
                        return Collect.MoneyTurretOneLevelThree;
                }
                break;

            case TurretType.Green:
                switch (baseTowerBuild.TurretLevel)
                {
                    case 1:
                        return Collect.MoneyTurretTwoLevelTwo;
                    case 2:
                        return Collect.MoneyTurretTwoLevelThree;
                }
                break;

            case TurretType.Blu:
                switch (baseTowerBuild.TurretLevel)
                {
                    case 1:
                        return Collect.MoneyTurretThreeLevelTwo;
                    case 2:
                        return Collect.MoneyTurretThreeLevelThree;
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
                    case 2:
                        return Collect.MoneyTurretOneLevelTwo;
                    case 3:
                        return Collect.MoneyTurretOneLevelThree;
                }
                break;

            case TurretType.Green:
                switch (baseTowerBuild.TurretLevel)
                {
                    case 1:
                        return Collect.MoneyTurretTwoLevelOne;
                    case 2:
                        return Collect.MoneyTurretTwoLevelTwo;
                    case 3:
                        return Collect.MoneyTurretTwoLevelThree;
                }
                break;

            case TurretType.Blu:
                switch (baseTowerBuild.TurretLevel)
                {
                    case 1:
                        return Collect.MoneyTurretThreeLevelOne;
                    case 2:
                        return Collect.MoneyTurretThreeLevelTwo;
                    case 3:
                        return Collect.MoneyTurretThreeLevelThree;
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
