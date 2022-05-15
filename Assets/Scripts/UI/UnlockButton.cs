using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UnlockButton : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
    }
}