using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure; // Required in C#

public class ControllerVibration : MonoBehaviour
{
   //define variables using in controller vibration
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    public ShipCollider SpaceshipColliderHolder;
    //the holder should be a gameobject contains only the colliders and public bool
    private bool IsHitted;
    public float VibrateStrength = 1f;
    public GameObject ShipMain;



    

    public void SpeedVibration() 
    {
        float SpeedVibStrength = Input.GetAxis("Forward") * 0.05f;
        GamePad.SetVibration(playerIndex, SpeedVibStrength, SpeedVibStrength);
    }
    
    void Start()
    {
        SpaceshipColliderHolder = FindObjectOfType<ShipCollider>();
        
        //need to add a WHOLE collider to the spaceship.
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float ShipSpeed = ShipMain.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        VibrateStrength = ShipSpeed / 12f;//calculate the vibration strength
        IsHitted = SpaceshipColliderHolder.isHitted;//detect if the ship is hitted from the holder
        
        
        if (IsHitted)
        {
            GamePad.SetVibration(playerIndex, VibrateStrength, VibrateStrength);
        }

        else 
        {
            GamePad.SetVibration(playerIndex, 0f, 0f);
        }
        //Debug.Log(IsHitted);
    }
}
