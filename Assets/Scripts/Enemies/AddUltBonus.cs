using System;
using UnityEngine;

public class AddUltBonus : MonoBehaviour
{
    private UltimateAbility ultScript;

    private void Start()
    {
        ultScript = GameObject.Find("Ult").GetComponent<UltimateAbility>();
        ultScript.bonus += 0.3f;
    }
}