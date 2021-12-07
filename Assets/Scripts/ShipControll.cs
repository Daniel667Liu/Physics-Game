
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
    public Vector3 ForwardDir;
    public Vector3 BackwardDir;
    public Vector3 LeftDir;
    public Vector3 RightDir;
    public Vector3 UpDir;
    public Vector3 DownDir;

    //get the force position
    public GameObject ForwardCubePos;
    public GameObject BackwardCubePos;
    public GameObject LeftCubePos;
    public GameObject RightCubePos;

    //define the force strength
    public float ForwardStrength ;
    public float PitchStrength ;
    public float RollStrength ;
    public float YawStrength ;

    //define the max force and the acceleration of force.
    public float MaxForceTimes = 2.0f;
    private float InitialForceTimes = 1.0f;
    private float ForceTimes = 1.0f; //only apply on the forward and backward forces.
    public float Acceleration = 0.1f;

    //if use controller or not
    public bool UseController = true;

    //define how to use the controller
    private bool isLeftControl = true;
    public float InputVertical;
    public float YawInput;

    private FreeLookSwitch FreeLookSwitch;
    //push the gas -> force increase, realse the gas -> force decrease.
    public void ForceLerp()
    {
        ForceTimes = Mathf.Lerp(InitialForceTimes, MaxForceTimes, Acceleration);
        InitialForceTimes = ForceTimes;
    }

    public void ReverseForceLerp()
    {
        ForceTimes = Mathf.Lerp(InitialForceTimes, 1.0f, Acceleration);
        InitialForceTimes = ForceTimes;
    }

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
        ForwardCubePos.GetComponent<Rigidbody>().AddForce(ForwardDir * ForwardStrength * ForceTimes * -1f, ForceMode.Impulse);
        BackwardCubePos.GetComponent<Rigidbody>().AddForce(ForwardDir * ForwardStrength * ForceTimes * -1f, ForceMode.Impulse);
    }

    //Move forward with controller
    public void ForwardWithCon() 
    {
        if (UseController) 
        {
            float ForwardInput = Input.GetAxis("Forward");
            ForwardCubePos.GetComponent<Rigidbody>().AddForce(ForwardDir * ForwardStrength * ForceTimes * ForwardInput * -1f, ForceMode.Impulse);
            BackwardCubePos.GetComponent<Rigidbody>().AddForce(ForwardDir * ForwardStrength * ForceTimes * ForwardInput * -1f, ForceMode.Impulse);
            
        }
    }

    public void MoveBackward() 
    {
        ForwardCubePos.GetComponent<Rigidbody>().AddForce(BackwardDir * ForwardStrength * ForceTimes * -1f, ForceMode.Impulse);
        BackwardCubePos.GetComponent<Rigidbody>().AddForce(BackwardDir * ForwardStrength * ForceTimes * -1f, ForceMode.Impulse);
    }

    //Move backward with controller
    public void BackwardWithCon() 
    {
        if (UseController) 
        {
            float BackwardInput = Input.GetAxis("Backward");
            ForwardCubePos.GetComponent<Rigidbody>().AddForce(BackwardDir * ForwardStrength * ForceTimes * BackwardInput * -1f, ForceMode.Impulse);
            BackwardCubePos.GetComponent<Rigidbody>().AddForce(BackwardDir * ForwardStrength * ForceTimes * BackwardInput * -1f, ForceMode.Impulse);
            //Debug.Log(BackwardInput);
        }
    }
    public void PitchUp() 
    {
        ForwardCubePos.GetComponent<Rigidbody>().AddForce(UpDir * PitchStrength * -1f, ForceMode.Impulse);
        BackwardCubePos.GetComponent<Rigidbody>().AddForce(DownDir * PitchStrength * -1f, ForceMode.Impulse);
    }

    public void PitchDown() 
    {
        ForwardCubePos.GetComponent<Rigidbody>().AddForce(DownDir * PitchStrength * -1f, ForceMode.Impulse);
        BackwardCubePos.GetComponent<Rigidbody>().AddForce(UpDir * PitchStrength * -1f, ForceMode.Impulse);
    }

    //pitch with controller
    public void PitchWithCon() 
    {
        if (UseController) 
        {
            
            if (isLeftControl)
            {   
                InputVertical = Input.GetAxis("Vertical"); 
            }
            else 
            {
                InputVertical = Input.GetAxis("Mouse Y");
            }
            ForwardCubePos.GetComponent<Rigidbody>().AddForce(DownDir * PitchStrength * InputVertical, ForceMode.Impulse);
            BackwardCubePos.GetComponent<Rigidbody>().AddForce(UpDir * PitchStrength * InputVertical, ForceMode.Impulse);
        }
    }
    public void YawLeft() 
    {
        ForwardCubePos.GetComponent<Rigidbody>().AddForce(LeftDir * YawStrength * -1f, ForceMode.Impulse);
        BackwardCubePos.GetComponent<Rigidbody>().AddForce(RightDir * YawStrength* -1f, ForceMode.Impulse);
    }

    public void YawRight() 
    {
        ForwardCubePos.GetComponent<Rigidbody>().AddForce(RightDir * YawStrength * -1f, ForceMode.Impulse);
        BackwardCubePos.GetComponent<Rigidbody>().AddForce(LeftDir * YawStrength * -1f, ForceMode.Impulse);
    }

    //control yaw with controller
    public void YawWithCon() 
    {
        
        if (isLeftControl)
        {
            YawInput = Input.GetAxis("Roll");
        }
        else 
        {
            YawInput = Input.GetAxis("Mouse X");
        }
        ForwardCubePos.GetComponent<Rigidbody>().AddForce(LeftDir * YawStrength * YawInput, ForceMode.Impulse);
        BackwardCubePos.GetComponent<Rigidbody>().AddForce(RightDir * YawStrength * YawInput, ForceMode.Impulse);
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


    //switch the controller side
    public void ControllerSwitch() 
    {
        if (isLeftControl)
        {
            isLeftControl = false;
        }
        else 
        {
            isLeftControl = true;
        }

        FreeLookSwitch.CameraControllSwitch();
    }
   
    


    void Start()
    {
        FreeLookSwitch = FindObjectOfType<FreeLookSwitch>();
    }

    // Update is called once per frame
    void Update()
    {
       //Debug.Log(isLeftControl);

        if (Input.GetKeyDown(KeyCode.G)) 
        {
            ControllerSwitch();
        }


        DirectionCal();

        //call controller func
        YawWithCon();
        PitchWithCon();
        ForwardWithCon();
        BackwardWithCon();

        

        //use keyboard ir controller
        if (Input.anyKey)
        {
            UseController = false;
        }
        else 
        {
            UseController = true;
        }
       


        if (Input.GetKey(KeyCode.UpArrow))
            {
                //MoveForward();
                PitchUp();
          
            }



        if (Input.GetKey(KeyCode.DownArrow))
            {
               //MoveBackward();
               PitchDown();
            
             }



        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.JoystickButton4))
            {
                RollLeft();
         
            }



        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.JoystickButton5))
            {
                RollRight();
           
            }



        if (Input.GetKey(KeyCode.W))
        {
            MoveForward();
            ForceLerp();
        }
        else 
        {
            ReverseForceLerp();
        }
        //push and release the gas control.
            



        if (Input.GetKey(KeyCode.S))
            {
                //PitchDown();
                MoveBackward();
              

            }
            

        if (Input.GetKey(KeyCode.A))
            {
                YawLeft();
            
            }



        if (Input.GetKey(KeyCode.D))
            {
                YawRight();
           
            }

       
    }
}
