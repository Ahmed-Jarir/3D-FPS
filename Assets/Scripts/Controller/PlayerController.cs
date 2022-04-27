using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

/// <summary>
/// This class handles the movement of the player with given input from the input manager
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Settings")] 
    [Tooltip("The Speed at which the player moves")]
    public float moveSpeed = 2f;

    [Tooltip("The Speed at which the player moves")]
    public float lookSpeed = 60f;

    [Tooltip("The Speed at which the player moves")]
    public float jumpPower = 8f;

    [Tooltip("The Speed at which the player moves")]
    public float gravity = 9.81f;

    [Header("Required References")]
    [Tooltip("the player shooter script that fires projectiles")]
    public Shooter playerShooter = null;


    public Health PlayerHealth;
    public List<GameObject> DisableItemsOnDeath;

    private float jumpTimeLeniency = 0.1f;
    private float TimeToStopBeingLenient = 0;
    private bool doubleJumpAvailable = false;

    private CharacterController controller;
    private InputManager inputManager;

    /// <summary>
    /// Description:
    /// Standard Unity function called once before the first Update call
    /// Input:
    /// none
    /// Return:
    /// void (no return)
    /// </summary>
    void Start()
    {
        SetUpCharacterController();
        SetUpInputManager();
    }

    void SetUpCharacterController()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("The player controller script does not have a player controller script attached to the same game object!");
        }
    }

    void SetUpInputManager()
    {
        inputManager = InputManager.instance;
    }

    /// <summary>
    /// Description:
    /// Standard Unity function called once every frame
    /// Input:
    /// none
    /// Return:
    /// void (no return)
    /// </summary>
    void Update()
    {
        if (PlayerHealth.currentHealth <= 0)
        {
            foreach(GameObject item in DisableItemsOnDeath)
            {
               item.SetActive(false); 
            }
            return;
        }
        else
        {
            foreach(GameObject item in DisableItemsOnDeath)
            {
               item.SetActive(true); 
            }
        }
        ProcessMovement();
        ProcessRotation();
    }

    private Vector3 moveDirection;
    void ProcessMovement()
    {
        
       // get the input from input manager 
       float LeftRightMovement = inputManager.horizontalMoveAxis;
       float ForwardBackwardMovement = inputManager.verticalMoveAxis;
       bool JumpPressed = inputManager.jumpPressed;
       if (controller.isGrounded)
       {
           doubleJumpAvailable = true;
           TimeToStopBeingLenient = Time.time + jumpTimeLeniency;
           moveDirection = new Vector3(LeftRightMovement, 0, ForwardBackwardMovement);
           moveDirection = transform.TransformDirection(moveDirection);
           moveDirection *= moveSpeed;
           if (JumpPressed)
           {
               moveDirection.y = jumpPower;
           }
       }
       else
       {
           moveDirection = new Vector3(LeftRightMovement * moveSpeed, moveDirection.y, ForwardBackwardMovement * moveSpeed);
           moveDirection = transform.TransformDirection(moveDirection);
           if (JumpPressed && Time.time < TimeToStopBeingLenient)
           {
               moveDirection.y = jumpPower;
           } 
           else if (JumpPressed && doubleJumpAvailable)
           {
               moveDirection.y = jumpPower;
               doubleJumpAvailable = false;
           }
       }

       moveDirection.y -= gravity * Time.deltaTime;
       
       if (controller.isGrounded && moveDirection.y < 0)
       {
           moveDirection.y = -0.3f;
       }
       controller.Move(moveDirection * Time.deltaTime);
    }

    void ProcessRotation()
    {
        float horizontalLookInput = inputManager.horizontalLookAxis;
        Vector3 playerRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(new Vector3(playerRotation.x, playerRotation.y + horizontalLookInput * lookSpeed * Time.deltaTime, playerRotation.z));
    }
}
