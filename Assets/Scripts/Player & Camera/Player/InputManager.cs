using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Currently only manages Jump.
 * Holding the jump key sets the gravityMultiplier at 2.
 * Releasing the jump key prematurely sets it at 4.
 */
namespace Player
{
    public class InputManager : MonoBehaviour
    {
        PlayerAction action;

        private void Awake()
        {
            action = GetComponent<PlayerAction>();
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                action.gravityMultiplier = 2f;
                action.Jump();
            }

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
                action.gravityMultiplier = 4f;
        }

        private void FixedUpdate()
        {
            action.PlayerMovement(Input.GetAxisRaw("Horizontal"));
        }
    }

}