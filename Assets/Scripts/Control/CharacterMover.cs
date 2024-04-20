using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
/**
Author:         Tanner Hunt
Date:           4/19/2024
Version:        0.1
Description:    This Code interfaces with the Character Controller component and handles
                basic character movement, like walking, strafing, and jumping.
ChangeLog:      V 0.1 -- 4/19/2024
                    --Imported code from unity docs under CharacterController.Move
                    --Altered code to move player in cameras forward facing direction
                    --added strafing
                    --NYI: Make Jumping more snappy by increasing and decreasing gravity with inputs
                    --Dev time: 2 Hours
*/

namespace Control{
public class CharacterMover : MonoBehaviour
{
    private CharacterController controller;             //the character controller component on the character
    private Vector3 playerVelocity;                     //how fast the character is moving
    private bool groundedPlayer;                        //whether or not the player is touching the ground
    [SerializeField]float playerSpeed = 2.0f;           //how fast the player should move
    [SerializeField]float jumpHeight = 1.0f;            //how heigh the player should jump
    [SerializeField]float gravityValue = -9.81f;        //the strength of gravity
    private CameraController cameraController;          //reference to the camera controller; determines the forward direction.

/// <summary>
/// Cache the camera controller and the character controller
/// </summary>
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        cameraController = this.transform.parent.GetComponentInChildren<CameraController>();
    }

/// <summary>
/// Checks the player for collisions with the ground.  Moves the player if they press
/// the movement buttons.  The player jumps if they press the jump key.
/// </summary>
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = forwardMovement() + strafe();
        move = move / magnitude(move);


        if (move != Vector3.zero)
        {
            controller.Move(move * Time.deltaTime * playerSpeed);
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

/// <summary>
/// Returns a forward or backward vector if the player presses the forward or backward
/// movement keys.
/// </summary>
/// <returns>Direction vector the player should be moved.</returns>
    private Vector3 forwardMovement(){
        Vector3 move = new Vector3();
        move.x = (float)Math.Sin(cameraController.getTheta()) * -1;
        move.y = 0;
        move.z = (float)Math.Cos(cameraController.getTheta()) * -1;
        move = move * forwardBackwardMovementInput();
        return move;
    }

/// <summary>
/// A helper function that determines whether the player is pressing the forward or
/// backward key.
/// </summary>
/// <returns>1 if the player presses forward, -1 if the player presses backward</returns>
    private int forwardBackwardMovementInput(){
        if(Input.GetKey("w")){
            return 1;
        }
        if(Input.GetKey("s")){
            return -1;
        }
        return 0;
    }

/// <summary>
/// Returns a vector perpindicular to the forward plane of the character for strafing
/// left and right.
/// </summary>
/// <returns>a perpindicular vector to the forward direction.</returns>
    private Vector3 strafe(){
        Vector3 move = new Vector3();
        if(Input.GetKey("d")){
            move.x = (float)Math.Cos(cameraController.getTheta()) * -1;
            move.y = 0;
            move.z = (float)Math.Sin(cameraController.getTheta());
            return move;
        } 
        if(Input.GetKey("a")){
            move.x = (float)Math.Cos(cameraController.getTheta());
            move.y = 0;
            move.z = (float)Math.Sin(cameraController.getTheta()) * -1;
            return move;
        } 
        return move;
    }

/// <summary>
/// A helper function that determines the magnitude of a vector.  Useful in normalizing
/// player movement direction if they press multiple inputs at the same time.
/// </summary>
/// <param name="vector3">The vector to be normalized</param>
/// <returns>the magnitude of vector3</returns>
    private float magnitude(Vector3 vector3){
        return(
            (float)Math.Sqrt(
                Math.Pow(vector3.x, 2) +
                Math.Pow(vector3.y, 2) +
                Math.Pow(vector3.z, 2)
            )
        );
    }

}
}