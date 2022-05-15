using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonUnlock : MonoBehaviour
{
   private string LevelName;
   private bool unlocked(int levelUnlocked) => levelUnlocked == 1 ? true : false;
   private void Awake()
   {
       LevelName = gameObject.name.Replace("Button", "");
   }

   private void Start()
   {
         gameObject.SetActive(unlocked(PlayerPrefs.GetInt(LevelName)));
   }
}