
using System;
using UnityEngine;
public class TimeDestructablePickups : Pickup
{
    private float timeForDestruction;
    public float timeUntilDestruction = 120;

    private void Awake()
    {
        timeForDestruction = Time.time + timeUntilDestruction;
    }

    private void Update()
    {
        if (Time.time >= timeForDestruction)
        {
            Destructable.DoDestroy(this.gameObject);
        }
    }
}