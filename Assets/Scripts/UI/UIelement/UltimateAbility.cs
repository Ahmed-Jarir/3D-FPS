using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateAbility : MonoBehaviour
{
    public List<Image> fillImage;
    public GameObject setActive;
    public Shooter PlayersShooter;
    public float bonus = 0;

    private float timeNeeded = 180; 
    private float timeToFullyCharge;

    private float abilityDuration = 10;
    private float timeToDisableAbility;

    private bool wasTriggered = false;
    private bool resetable = false;
    
    private InputManager inputManager;

    private void Awake()
    {
        timeToFullyCharge = Time.time + timeNeeded;
    }

    private void Start()
    {
        inputManager = InputManager.instance;
    }

    private void Update()
    {
        waitAndCheckforAbility();
        if (Time.time >= timeToDisableAbility && resetable)
        {
            ResetAbility();
        }
    }

    private void waitAndCheckforAbility()
    {
        //fill images until ability is fully charged 
        if ((Time.time + bonus) < timeToFullyCharge)
        {
            foreach (Image fill in fillImage)
            {
                fill.fillAmount = (float) (Time.time + bonus) / (float) timeToFullyCharge;
            }
        }
        else if ((Time.time + bonus) >= timeToFullyCharge && !wasTriggered && inputManager.ultIsPressed)
        {
            TriggerAbility();
            
        }
        if ((Time.time + bonus) >= timeToFullyCharge && !wasTriggered)
        {
            setActive.SetActive(true);
        }
        else
        {
            setActive.SetActive(false);
        }
        
        //unfill until the ability is reset
         if (resetable)
         {
             foreach (Image fill in fillImage)
             {
                 fill.fillAmount =  (timeToDisableAbility - Time.time) / abilityDuration;
             }
         } 
    }

    private void TriggerAbility()
    {
        wasTriggered = true;
        foreach (Gun gun in PlayersShooter.guns)
        {
            gun.fireType = Gun.FireType.automatic;
            gun.useAmmo = false;
        }

        timeToDisableAbility = Time.time + abilityDuration;
        resetable = true;
    }

    private void ResetAbility()
    {

        foreach (Gun gun in PlayersShooter.guns)
        {
            gun.fireType = gun.defaultfireType;
            gun.useAmmo = gun.defaultUseAmmo;
        }

        wasTriggered = false;
        resetable = false;
        bonus = 0;
        timeToFullyCharge = Time.time + timeNeeded;
    }
}