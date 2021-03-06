using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pickup-derived class which adds a gun to a player's shooter component
/// </summary>
public class GunUpgradePickup : Pickup
{
    [Header("Gun Pickup Settings")]
    [Tooltip("The index of the gun to make available in the shooter script")]
    public int gunIndexToMakeAvailable = 0;

    public int gunIndexToUpgradeFrom = 0;

    public List<string> PreviousGunsName;
    public string NewGunName;

    /// <summary>
    /// Description:
    /// Adds a gun to the player's shooter component when picked up
    /// Input: 
    /// Collider collision
    /// Return: 
    /// void (no return)
    /// </summary>
    /// <param name="collision">The collider that is picking this up</param>
    public override void DoOnPickup(Collider collision)
    {
        Shooter shooter = collision.gameObject.GetComponentInChildren<Shooter>();
        if (collision.tag == "Player" && shooter != null && shooter.guns[gunIndexToUpgradeFrom].available && !shooter.guns[gunIndexToUpgradeFrom].upgraded)
        {
            shooter.MakeGunAvailable(gunIndexToMakeAvailable);
            shooter.MakeGunUnavailable(gunIndexToUpgradeFrom);
            shooter.guns[gunIndexToUpgradeFrom].upgraded = true;
            if (NewGunName != null && PreviousGunsName != null)
            {
                PlayerPrefs.SetInt(NewGunName, 1);
                foreach (string gun in PreviousGunsName)
                {
                    PlayerPrefs.SetInt(gun, 2);
                }
            }

            base.DoOnPickup(collision);
        }
    }
}
