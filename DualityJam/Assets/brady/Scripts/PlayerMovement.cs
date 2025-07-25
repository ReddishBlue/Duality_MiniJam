using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 100f;
    
    private DualityJamActions playerInputActions;
    // public Animator animator;
    
    public MyCharacterRenderer charRenderer;
    
    public PlayerCombat playerCombat;

    Rigidbody2D rbody;




    private void Awake()
    {
        playerInputActions = new DualityJamActions();
        rbody = GetComponent<Rigidbody2D>();
        charRenderer = GetComponent<MyCharacterRenderer>();

    }

    private void OnEnable()
    {
        playerInputActions.Player.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Player.Disable();
    }

    private void FixedUpdate() 
    {
        Movement();
        
    }

    public void OnExit()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private Vector3 VectorToCursor()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Calculate direction vector from prefab to mouse
        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return direction;
    }

    private Vector2 MovePlayer(Vector2 movement)
    {
        
        Vector2 currentPos = rbody.position;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        // if (animationController != null)
        // {
        //     if (movement.magnitude > 0.1f)
        //     {
        //         if (!animationController.walking)
        //         {
        //             animationController.StartedWalking();
        //         }
        //     }
        //     else
        //     {
        //         if (animationController.walking)
        //         {
        //             animationController.StoppedWalking();
        //         }
        //     }
        // }
        
        if(charRenderer != null)
            charRenderer.SetLookDirection(VectorToCursor());
            charRenderer.SetMoveDirection(movement);
        rbody.MovePosition(newPos);

        return newPos;
    }

    private void Movement()
    {
        Vector2 input = playerInputActions.Player.Move.ReadValue<Vector2>();

        float speed = movementSpeed;

        // Debug.Log("speed = " + speed);
        Vector2 movement = input * speed;

        MovePlayer(movement);
        

    }
}
