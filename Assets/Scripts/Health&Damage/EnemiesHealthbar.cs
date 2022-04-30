using System;
using UnityEngine;
public class EnemiesHealthbar : MonoBehaviour
{
    public Transform healthBar;
    public Health targetHealth;
    private int prevHealth;

    private void Awake()
    {
        prevHealth = targetHealth.currentHealth;
    }

    private void Update()
    {
        if (prevHealth > targetHealth.currentHealth)
        {
            changeColorAndFill();
        }
    }

    public void changeColorAndFill()
    {

        prevHealth = targetHealth.currentHealth;
        healthBar.localScale = new Vector3((float) targetHealth.currentHealth / (float) targetHealth.defaultHealth,
            healthBar.localScale.y, healthBar.localScale.z);
        
        healthBar.position = new Vector3(healthBar.position.x + healthBar.localScale.x / 2, healthBar.position.y,
            healthBar.position.z);
            
        //if(healthBar.localScale.x< 0.2f)
        //{
        //    healthBar.color = Color.red;
        //}

        //else if(healthBar.localScale.x< 0.4f)
        //{
        //    healthBar.color = Color.yellow;
        //}

        //else
        //{
        //    healthBar.color = Color.green;
        //}
    }
}