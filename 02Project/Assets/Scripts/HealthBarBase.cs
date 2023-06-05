using Assets.Scripts.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBase : MonoBehaviour
{
    public static HealthBarBase Instance;
    public Image healthBar;

    internal float maxHealth = 500f;
    internal float currentHealth;

    private void Awake()
    {
        Instance= this;
    }
    private void Start()
    {
        currentHealth = maxHealth;
    }
}
