using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControll : MonoBehaviour
{
    // Start is called before the first frame update

    //get the reference object for define position.
    public GameObject UpPos;
    public GameObject DownPos;
    public GameObject LeftPos;
    public GameObject RightPos;
    public GameObject ForwardPos;
    public GameObject BackwardPos;

    //store the direction of foreces
    private Vector3 ForwardDir;
    private Vector3 BackwardDir;
    private Vector3 LeftDir;
    private Vector3 RightDir;
    private Vector3 UpDir;
    private Vector3 DownDir;

    //get the force position
    public GameObject ForwardCubePos;
    public GameObject BackwardCubePos;
    public GameObject LeftCubePos;
    public GameObject RightCubePos;

    //define the force strength
    public float ForwardStrength = 0.1f;
    public float PitchStrength = 0.1f;
    public float RollStrength = 0.1f;
    public float YawStrength = 0.1f;
    


    //calculate the direction of forces.
    private void DirectionCal()
    {
        UpDir = (DownPos.gameObject.transform.position - UpPos.gameObject.transform.position).normalized;
        DownDir = (UpPos.gameObject.transform.position - DownPos.gameObject.transform.position).normalized;
        LeftDir = (RightPos.gameObject.transform.position - LeftPos.gameObject.transform.position).normalized;
        RightDir = (LeftPos.gameObject.transform.position - RightPos.gameObject.transform.position).normalized;
        ForwardDir = (BackwardPos.gameObject.transform.position - ForwardPos.gameObject.transform.position).normalized;
        BackwardDir = (ForwardPos.gameObject.transform.position - BackwardPos.gameObject.transform.position).normalized;

    }


    //decalre the move functions.
    public void MoveForward() 
    {
        ForwardCubePos.GetComponent<Rigidbody>().AddForce(ForwardDir * ForwardStrength * -1f, ForceMode.Impulse);
        BackwardCubePos.GetComponent<Rigidbody>().AddForce(ForwardDir * ForwardStrength * -1f, ForceMode.Impulse);
    }

    public void MoveBackward() 
    {
        ForwardCubePos.GetComponent<Rigidbody>().AddForce(BackwardDir * ForwardStrength * -1f, ForceMode.Impulse);
        BackwardCubePos.GetComponent<Rigidbody>().AddForce(BackwardDir * ForwardStrength * -1f, ForceMode.Impulse);
    }

    public void PitchUp() 
    {
        ForwardCubePos.GetComponent<Rigidbody>().AddForce(UpDir * PitchStrength, ForceMode.Impulse);
        BackwardCubePos.GetComponent<Rigidbody>().AddForce(DownDir * PitchStrength, ForceMode.Impulse);
    }

    public void PitchDown() 
    {
        ForwardCubePos.GetComponent<Rigidbody>().AddForce(DownDir * PitchStrength, ForceMode.Impulse);
        BackwardCubePos.GetComponent<Rigidbody>().AddForce(UpDir * PitchStrength, ForceMode.Impulse);
    }

    public void YawLeft() 
    {
        ForwardCubePos.GetComponent<Rigidbody>().AddForce(LeftDir * YawStrength, ForceMode.Impulse);
        BackwardCubePos.GetComponent<Rigidbody>().AddForce(RightDir * YawStrength, ForceMode.Impulse);
    }

    public void YawRight() 
    {
        ForwardCubePos.GetComponent<Rigidbody>().AddForce(RightDir * YawStrength, ForceMode.Impulse);
        BackwardCubePos.GetComponent<Rigidbody>().AddForce(LeftDir * YawStrength, ForceMode.Impulse);
    }

    public void RollLeft() 
    {
        LeftCubePos.GetComponent<Rigidbody>().AddForce(UpDir * RollStrength, ForceMode.Impulse);
        RightCubePos.GetComponent<Rigidbody>().AddForce(DownDir * RollStrength, ForceMode.Impulse);
    }

    public void RollRight() 
    {
        LeftCubePos.GetComponent<Rigidbody>().AddForce(DownDir * RollStrength, ForceMode.Impulse);
        RightCubePos.GetComponent<Rigidbody>().AddForce(UpDir * RollStrength, ForceMode.Impulse);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DirectionCal();

        if (Input.GetKey(KeyCode.UpArrow)) 
            PitchUp();

        if (Input.GetKey(KeyCode.DownArrow))
            PitchDown();

        if (Input.GetKey(KeyCode.LeftArrow)) 
            RollLeft();

        if (Input.GetKey(KeyCode.RightArrow))
            RollRight();

        if (Input.GetKey(KeyCode.W))
            MoveForward();

        if (Input.GetKey(KeyCode.S)) 
            MoveBackward();

        if (Input.GetKey(KeyCode.A)) 
            YawLeft();

        if (Input.GetKey(KeyCode.D)) 
            YawRight();

    }
}
