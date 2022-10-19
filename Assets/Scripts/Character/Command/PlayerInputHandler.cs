using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace  Character.Command
{
  
    public class PlayerInputHandler : InputHandler
    {
        private Controls playerControls;

        public override void Initialize()
        {
            Debug.Log("Initialized User");
            playerControls = new Controls();
            playerControls.Gameplay.Enable();
            AddInputCallbacks();
        }

        public override IEnumerator StartBrain()
        {
            Debug.Log("Brain Started");
            yield return null;
        }

        private void AddInputCallbacks()
        {
            Debug.Log("Input Callback Added");
            playerControls.Gameplay.Movement.performed += ctx => HandleMovement(ctx);
            playerControls.Gameplay.Movement.canceled += ctx => HandleMovement(ctx);
            playerControls.Gameplay.PrimaryAttack.performed += ctx => HandleAttack(ctx);
        }

        private void HandleAttack(InputAction.CallbackContext ctx)
        {
            AddCommand(Attack);
        }

        private void HandleMovement(InputAction.CallbackContext ctx)
        {
            if (ctx.ReadValue<Vector2>().x != 0)
            {
                if (ctx.ReadValue<Vector2>().x >= 1)
                {
                    AddCommand(MoveRight);
                    return;
                }

                AddCommand(MoveLeft);
                return;
            }

            if (ctx.ReadValue<Vector2>().y != 0)
            {
                if (ctx.ReadValue<Vector2>().y >= 1)
                {
                    AddCommand(MoveUp);
                    return;
                }
                AddCommand(MoveDown);
            }
        }
    }
        
}
    
    

