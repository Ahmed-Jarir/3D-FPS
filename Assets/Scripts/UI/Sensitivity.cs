using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensitivity : MonoBehaviour
{
    private float sensitivity;
    private PlayerController playercontroller;
    private CameraController cameracontroller;
    public Text text;
    public Slider slider;
    public GameObject player;
    public Camera cam;

    private void Awake()
    {
        if (PlayerPrefs.GetFloat("sensitivity") == 0)
        {
            PlayerPrefs.SetFloat("sensitivity",15);
        }
        sensitivity = PlayerPrefs.GetFloat("sensitivity");
        playercontroller = player.GetComponent<PlayerController>();
        cameracontroller = cam.GetComponent<CameraController>();
    }

    void Start()
    {
        if (text != null)
        {
            text.text = sensitivity.ToString();
        }
        if (slider != null)
        {
            slider.value = sensitivity / 100;
        }
    }

    private void Update()
    {
        setSens(slider.value * 100);
        if (text != null)
        {
            text.text = sensitivity.ToString();
        }
    }

    private void setSens(float sens)
    {
        sensitivity = sens;
        if(player != null && cam != null)
        {
            playercontroller.lookSpeed = sens;
            cameracontroller.rotationSpeed = sens;
        }
        PlayerPrefs.SetFloat("sensitivity", sens);
    }
}