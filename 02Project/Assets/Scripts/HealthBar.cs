using Assets.Scripts.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Enemy enemy;
    public Image healthBar;
    public Transform healthBarPosition;
    public Transform container;

    private Vector3 offset;

    void Start()
    {
    }

     void Update()
    {
        if (healthBarPosition != null)
        {
            Vector3 targetPosition = healthBarPosition.position + offset;
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetPosition);
            container.position = screenPosition;
        }

        SetHealthBarValue();
    }
    public void SetHealthBarValue()
    {
            healthBar.fillAmount = enemy.Health / enemy.MaxHealth;
    }

}
