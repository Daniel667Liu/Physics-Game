using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController charController;
    //public Animator 
    float InputX;
    float InputZ;
    Vector3 v_movement;
    Vector3 v_velocity;
    [Header("Movement Data")]
    public float moveSpeed;
    public float gravity;
    public float jumpForce;
    public float rotateSpeed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //is ground
        if(charController.isGrounded)
        {
            v_velocity.y = 0f;
        }
        else
        {
            v_velocity.y -= gravity * Time.deltaTime;
        }
        //jump
        if (Input.GetKey(KeyCode.Space)&& charController.isGrounded)
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            v_velocity.y += jumpForce;
        }

        if (charController.isGrounded)
        {
            InputX = Input.GetAxis("Horizontal");
            InputZ = Input.GetAxis("Vertical");
        }

        v_movement = charController.transform.forward * InputZ;

        charController.transform.Rotate(Vector3.up * InputX * (rotateSpeed * Time.deltaTime));

        charController.Move(v_movement * moveSpeed * Time.deltaTime);
        charController.Move(v_velocity);
    }
}
