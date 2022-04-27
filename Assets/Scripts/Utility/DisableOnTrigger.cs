using System;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnTrigger : MonoBehaviour
{
    public List<GameObject> ObjectsToDisable;

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.tag == "Player")
        {
            foreach (GameObject disable in ObjectsToDisable)
            {
                disable.SetActive(false);
            }
        }
    }
}