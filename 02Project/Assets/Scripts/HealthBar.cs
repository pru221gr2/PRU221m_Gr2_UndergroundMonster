using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
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

        //Test Health Bar 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            healthBar.fillAmount -= 0.1f;
        }
    }

}
