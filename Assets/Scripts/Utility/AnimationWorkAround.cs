using System;
using UnityEngine;

public class AnimationWorkAround : MonoBehaviour
{
    public Animator anim;
    public GameObject gun;


    private void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            Debug.Log("triggered");
            gun.transform.localRotation = Quaternion.Euler(0,0,0);
        }
    }
}