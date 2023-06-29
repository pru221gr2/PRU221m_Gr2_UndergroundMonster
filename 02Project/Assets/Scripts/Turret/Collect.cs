using Assets.Scripts.Enemy;
using Assets.Scripts.Turret;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    public static int countCoin = 2000;
    public const int MoneyTurretOneLevelOne = 100;
    public const int MoneyTurretOneLevelTwo = 300;
    public const int MoneyTurretOneLevelThree = 900;
    public const int MoneyTurretTwoLevelOne = 200;
    public const int MoneyTurretTwoLevelTwo = 400;
    public const int MoneyTurretTwoLevelThree = 1100;
    public const int MoneyTurretThreeLevelOne = 500;
    public const int MoneyTurretThreeLevelTwo = 1000;
    public const int MoneyTurretThreeLevelThree = 2000;

    public static int countTrophy = 0;

    internal Text coinText;

    internal Text trophyText;

    protected virtual void Start()
    {
        coinText = GameObject.Find("Coin_Value").GetComponent<Text>();
        trophyText = GameObject.Find("Score_Value").GetComponent<Text>();
    }
    private void Update()
    {
        coinText.text = countCoin.ToString();
        trophyText.text = countTrophy.ToString();
    }
}
