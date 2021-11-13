using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<AddForce> Engines;
    public AddForce Engine;

    public GameObject SpaceShip;
    Rigidbody SpaceShip_rb;
    void Awake()
    {
        SpaceShip_rb = SpaceShip.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Player1 pitch axis and yall axis
        //Yaw Left/ left rotate
        if (Input.GetKey(KeyCode.A))
        {
            SpaceShip.transform.Rotate(0f, 0.0f, 2f * Time.deltaTime, Space.Self);
            //Engines[0].is_engineStart = true;
        }
        //Yaw right/ right rotate
        if (Input.GetKey(KeyCode.D))
        {
            SpaceShip.transform.Rotate(0f, 0.0f, -2f * Time.deltaTime, Space.Self);
            //Engines[1].is_engineStart = true;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Pitch up
        if (Input.GetKey(KeyCode.W))
        {
            //Engines[3].is_engineStart = true;
        }

        //Pitch down
        if (Input.GetKey(KeyCode.S))
        {
            //Engines[4].is_engineStart = true;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Player1 pitch axis and Forward/Back axis
        //Forward
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Engines[5].is_engineStart = true;
            SpaceShip_rb.AddForce(0f, 0f, 0.5f, ForceMode.Impulse);
        }
        //Back
        if (Input.GetKey(KeyCode.DownArrow))
        {
            SpaceShip_rb.AddForce(0f, 0f, -0.5f, ForceMode.Impulse);
            //Engines[6].is_engineStart = true;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //roll left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Engines[7].is_engineStart = true;
        }
        //roll right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Engines[8].is_engineStart = true;
        }


    }
}
