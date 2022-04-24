using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Teleporter : MonoBehaviour
{
    public GameObject player;
    public Transform TeleportTo;

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player"){
            player.GetComponent<CharacterController>().Move(TeleportTo.position - player.transform.position);
        }
        Debug.Log(collision.tag + "\n" + player.transform.position);
    }
}