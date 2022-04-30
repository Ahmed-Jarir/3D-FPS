using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RageMode : MonoBehaviour
{
    public Health BossHealth;
    public List<GameObject> ItemsToMakeAvailable;
    public GameObject SpawnersToIncreaseTheRateOf;
    public int spawnersNewRate = 20;
    public GameObject rageEffect = null;
    public float TimeToResetInvincibilityTime;
    
    private List<EnemySpawner> spawnerScripts = new List<EnemySpawner>();
    private bool Triggered = false;
    private bool triggerable = false;


    private void Awake()
    {
        int index = 0;
        List<GameObject> Spawners = new List<GameObject>();
        GameObject spawner;
        while (true)
        {
            try{
                spawner = SpawnersToIncreaseTheRateOf.transform.GetChild(index).gameObject;
            }
            catch(UnityException e)
            {
                break;
            }
            Spawners.Add(spawner);
            index++;
        }
        foreach (GameObject Spawner in Spawners)
        {
            spawnerScripts.Add(Spawner.transform.GetChild(0).gameObject.GetComponent<EnemySpawner>());
        }
    }

    void Update()
    {
        if (!Triggered && BossHealth.currentHealth <= (BossHealth.defaultHealth * 0.2))
        {
          TriggerWhenConditionsAreMet();  
        }

        if (TimeToResetInvincibilityTime <= Time.time && triggerable)
        {
            BossHealth.invincibilityTime = 0;
            triggerable = false;
        }
    }

    void TriggerWhenConditionsAreMet()
    {
        Triggered = true;
        if (rageEffect != null)
        {
            Instantiate(rageEffect, transform.position, Quaternion.identity, null);
        }
        foreach (EnemySpawner script in spawnerScripts)
        {
            script.spawnRate = spawnersNewRate;
        }

        foreach (GameObject item in ItemsToMakeAvailable)
        {
            item.SetActive(true);
        }
        TimeToResetInvincibilityTime = Time.time + 10;
        BossHealth.invincibilityTime = 10;
        triggerable = true;
    }
}
