using System;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{ 
     private float volume;
     public Text text;
     public Slider slider;
 
     private void Awake()
     { 
         if (PlayerPrefs.GetFloat("volume") == 0)
         {
             PlayerPrefs.SetFloat("volume",1);
         }
         volume = PlayerPrefs.GetFloat("volume");
         
     }
 
     void Start()
     {
         if (text != null)
         {
             text.text = volume.ToString();
         }
         if (slider != null)
         {
             slider.value = volume;
         }
     }
 
     private void Update()
     {
         setVol(slider.value);
         if (text != null)
         {
             text.text = (volume*100).ToString();
         }
     }
 
     private void setVol(float vol)
     {
         volume = vol;
         AudioListener.volume = volume;
         PlayerPrefs.SetFloat("volume", vol);
     }
}