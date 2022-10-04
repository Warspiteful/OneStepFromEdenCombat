using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GridController : MonoBehaviour
{

    [SerializeField] private Transform movePoint;
    [SerializeField] private float speed; 
    
    [SerializeField] private Controls playerControls;
    
    

    private void OnEnable()
    {
        playerControls = new Controls();
        playerControls.Gameplay.Enable();
        playerControls.Gameplay.Movement.performed += ctx => HandleMovement(ctx);

    }


    private void HandleMovement(InputAction.CallbackContext ctx)
    {
        movePoint.position += new Vector3(  ctx.ReadValue<Vector2>().x,  ctx.ReadValue<Vector2>().y);

    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, Time.deltaTime * speed);
    }

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }
}
