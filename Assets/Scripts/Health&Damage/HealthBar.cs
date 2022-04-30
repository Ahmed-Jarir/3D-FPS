
using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public Health targetHealth;

    private void Update()
    {
       changeColorAndFill(); 
    }

    private void changeColorAndFill() {
        healthBar.fillAmount = (float)targetHealth.currentHealth/(float)targetHealth.defaultHealth;
        if (targetHealth.getisInvincible())
        {
            healthBar.color = Color.blue;
        }
        else if(healthBar.fillAmount< 0.2f)
        {
            healthBar.color = Color.red;
        }

        else if(healthBar.fillAmount< 0.4f)
        {
            healthBar.color = Color.yellow;
        }

        else
        {
            healthBar.color = Color.green;
        }
    }
}
