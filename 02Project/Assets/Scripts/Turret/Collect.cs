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
    public static int countCoin = 0;

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
