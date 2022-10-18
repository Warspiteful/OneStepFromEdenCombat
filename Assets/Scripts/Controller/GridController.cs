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

    [SerializeField] private GridVariable grid;

    private int newX, newY;
    private int lastX, lastY;
    
    

    private void OnEnable()
    {
        lastX = 0;
        lastY = 0;
        playerControls = new Controls();
        playerControls.Gameplay.Enable();
        playerControls.Gameplay.Movement.performed += ctx => HandleMovement(ctx);
        playerControls.Gameplay.Movement.canceled += ctx => HandleMovement(ctx);

    }
    
    


    private void HandleMovement(InputAction.CallbackContext ctx)
    {

     if(transform.position == movePoint.position){
        if((int)Mathf.Round(ctx.ReadValue<Vector2>().x) != lastX)
        {
            lastX = (int) Mathf.Round(ctx.ReadValue<Vector2>().x);
            newX = (int) Mathf.Round(movePoint.position.x + ctx.ReadValue<Vector2>().x);
            if (newX < grid.width / 2 && newX >= -grid.width / 2)
            {
                newY = (int) transform.position.y;
                if(grid.GetAlignment(newX + grid.width / 2, newY + grid.height / 2) == Alignment.PLAYER){
                    movePoint.position = new Vector3(newX, newY);
                }
            }
        }
        else if ((int)Mathf.Round(ctx.ReadValue<Vector2>().y) != lastY)
        {
            lastY = (int) Mathf.Round(ctx.ReadValue<Vector2>().y);
            newY = (int) Mathf.Round(movePoint.position.y + ctx.ReadValue<Vector2>().y);
     

            if (newY < grid.height / 2 && newY >= -grid.height / 2)
            {
                newX = (int) transform.position.x;
                if(grid.GetAlignment(newX + grid.width / 2, newY + grid.height / 2) == Alignment.PLAYER){
                    movePoint.position = new Vector3(newX, newY);
                }
            }
        }
        }
        
        
        

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
