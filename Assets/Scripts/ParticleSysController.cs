using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSysController : MonoBehaviour
{
    public ShipControll  SC;
    //public GameObject SpaceShip;

    public float StartLifeTime, Zero;

    ParticleSystem.MainModule sysMain;

    public ParticleSystem [] RollsL;
    public ParticleSystem[] RollsR;
    public ParticleSystem [] MovesF;
    public ParticleSystem [] PitchesU;
    public ParticleSystem[] PitchesD;
    public ParticleSystem [] YawsL;
    public ParticleSystem[] YawsR;

    //Adjustment Syste
    public Vector3 YawV;
    public Vector3 PitchV;
    public Vector3 RollV;

    float AdjLifeTime = 0.1f;
    float startLifeTime = 0.2f;

    private void OnEnable()
    {
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        YawV = Vector3.Project(SC.ForwardCubePos.GetComponent<Rigidbody>().GetPointVelocity(SC.ForwardCubePos.GetComponent<Rigidbody>().position), SC.LeftDir).normalized;
        PitchV = Vector3.Project(SC.ForwardCubePos.GetComponent<Rigidbody>().GetPointVelocity(SC.ForwardCubePos.GetComponent<Rigidbody>().position), SC.UpDir).normalized;
        RollV = Vector3.Project(SC.LeftCubePos.GetComponent<Rigidbody>().GetPointVelocity(SC.ForwardCubePos.GetComponent<Rigidbody>().position), SC.UpDir).normalized;

        //Debug.Log(SC.ForwardCubePos.GetComponent<Rigidbody>().velocity);
        //Debug.Log(SC.ForwardCubePos.GetComponent<Rigidbody>().GetPointVelocity(SC.ForwardCubePos.GetComponent<Rigidbody>().position));
        //Debug.Log(Vector3.Project(SC.ForwardCubePos.GetComponent<Rigidbody>().GetPointVelocity(SC.ForwardCubePos.GetComponent<Rigidbody>().position),SC.LeftDir));
        //Debug.Log(Vector3.Project(SC.ForwardCubePos.GetComponent<Rigidbody>().GetPointVelocity(SC.ForwardCubePos.GetComponent<Rigidbody>().position), SC.LeftDir).normalized);
        //Debug.Log(Vector3.Project(SC.ForwardCubePos.GetComponent<Rigidbody>().GetPointVelocity(SC.ForwardCubePos.GetComponent<Rigidbody>().position), SC.LeftDir).magnitude);

        //Debug.Log(SC.LeftDir);
        //Debug.Log(YawV);
        //Pose Adjustment System 


        //Particle System of ship movement
        if (Input.GetKey(KeyCode.UpArrow))
        {
            PitchU();
        }
        else
        {
            PitchUclose();
        }



        if (Input.GetKey(KeyCode.DownArrow))
        {
            //MoveBackward();
            PitchD();

        }
        else
        {
            PitchDclose();
        }



        if (Input.GetKey(KeyCode.LeftArrow))
        {
            RollL();

        }
        else
        {
            RollLclose();
        }



        if (Input.GetKey(KeyCode.RightArrow))
        {
            RollR();

        }
        else
        {
            RollRclose();
        }


        if (Input.GetKey(KeyCode.W))
        {
            //PitchUp();
            MoveF();
        }
        else
        {
            MoveFclose();
        }


        if (Input.GetKey(KeyCode.S))
        {
            MoveB();

        }
        else
        {
            MoveBclose();
        }


        if (Input.GetKey(KeyCode.A))
        {
            YawL();
        }
        else
        {
            YawLclose();
            //Adjustment     
        }


        if (Input.GetKey(KeyCode.D))
        {
            YawR();

        }
        else
        {
            YawRclose();
        }

        if(!Input.anyKey)
        {
            //Yaw adjustment
            YawRclose();
            YawLclose();
            if (YawV == SC.LeftDir)
            {
                //Debug.Log("Equal true YawR");
                YawLadj();
            }
            else if (YawV == Vector3.zero)
            {
                YawRclose();
                YawLclose();
            }
            else if (YawV != SC.LeftDir)
            {
               // Debug.Log("Equal true YawL");
                YawRadj();
            }

            //Pitch adjustment
            PitchUclose();
            PitchDclose();
            if (PitchV == SC.UpDir)
            {
                //Debug.Log("Equal true YawR");
                PitchDadj();
            }
            else if (PitchV == Vector3.zero)
            {
                PitchUclose();
                PitchDclose();
            }
            else if (PitchV != SC.UpDir)
            {
                //Debug.Log("Equal true YawL");
                PitchUadj();
            }

            //Roll adjustment
            RollRclose();
            RollLclose();
            if (RollV == SC.UpDir)
            {
               // Debug.Log("Equal true YawR");
                RollLadj();
            }
            else if (RollV == Vector3.zero)
            {
                RollRclose();
                RollLclose();
            }
            else if (RollV != SC.UpDir)
            {
                //Debug.Log("Equal true YawL");
                RollRadj();
            }
        }
    }

    public void MoveF()
    {
        foreach (ParticleSystem smoke in MovesF)
        {
            var StartLifeTime = smoke.main;
            StartLifeTime.startLifetime = startLifeTime;
        }
    }
    public void MoveFclose()
    {
        foreach (ParticleSystem smoke in MovesF)
        {
            var StartLifeTime = smoke.main;
            StartLifeTime.startLifetime =0f;
        }
    }
    public void MoveB()
    {

    }
    public void MoveBclose()
    {

    }
    //------------------------------------------------------------------------------------------------------

    public void PitchU()
    {
        foreach (ParticleSystem smoke in PitchesU)
        {
            var StartLifeTime = smoke.main;
            StartLifeTime.startLifetime = startLifeTime;
        }
    }
    public void PitchUadj()
    {
        foreach (ParticleSystem smoke in PitchesU)
        {
            var StartLifeTime = smoke.main;
            StartLifeTime.startLifetime = AdjLifeTime;
        }
    }
    public void PitchUclose()
    {
        foreach (ParticleSystem smoke in PitchesU)
        {
            var StartLifeTime = smoke.main;
            StartLifeTime.startLifetime = 0f;
        }
    }
    public void PitchD()
    {
        foreach (ParticleSystem smoke in PitchesD)
        {
            var StartLifeTime = smoke.main;
            StartLifeTime.startLifetime = startLifeTime;
        }
    }
    public void PitchDadj()
    {
        foreach (ParticleSystem smoke in PitchesD)
        {
            var StartLifeTime = smoke.main;
            StartLifeTime.startLifetime = AdjLifeTime;
        }
    }
    public void PitchDclose()
    {
        foreach (ParticleSystem smoke in PitchesD)
        {
            var StartLifeTime = smoke.main;
            StartLifeTime.startLifetime = 0f;
        }
    }
//------------------------------------------------------------------------------------------------------
    public void YawL()
    {
        foreach (ParticleSystem smoke in YawsL)
        {
            var StartLifeTime = smoke.main;
            StartLifeTime.startLifetime = startLifeTime;
        }
    }
    public void YawLadj()
    {
        foreach (ParticleSystem smoke in YawsL)
        {
            var StartLifeTime = smoke.main;
            StartLifeTime.startLifetime = AdjLifeTime;
        }
    }
    public void YawLclose()
    {
        foreach (ParticleSystem smoke in YawsL)
        {
            var StartLifeTime = smoke.main;
            StartLifeTime.startLifetime = 0f;
        }
    }
    public void YawR()
    {
        foreach (ParticleSystem smoke in YawsR)
        {
            var StartLifeTime = smoke.main;
            StartLifeTime.startLifetime = startLifeTime;
        }
    }
    public void YawRadj()
    {
        foreach (ParticleSystem smoke in YawsR)
        {
            var StartLifeTime = smoke.main;
            StartLifeTime.startLifetime = AdjLifeTime;
        }
    }
    public void YawRclose()
    {
        foreach (ParticleSystem smoke in YawsR)
        {
            var StartLifeTime = smoke.main;
            StartLifeTime.startLifetime = 0f;
        }
    }
    //------------------------------------------------------------------------------------------------------

    public void RollL()
    {
        foreach (ParticleSystem smoke in RollsL)
        {
            var StartLifeTime = smoke.main;
            StartLifeTime.startLifetime = startLifeTime;
        }
    }

    public void RollLadj()
    {
        foreach (ParticleSystem smoke in RollsL)
        {
            var StartLifeTime = smoke.main;
            StartLifeTime.startLifetime = AdjLifeTime;
        }
    }
    public void RollLclose()
    {
        foreach (ParticleSystem smoke in RollsL)
        {
            var StartLifeTime = smoke.main;
            StartLifeTime.startLifetime = 0f;
        }
    }
    public void RollR()
    {
        foreach (ParticleSystem smoke in RollsR)
        {
            var StartLifeTime = smoke.main;
            StartLifeTime.startLifetime = startLifeTime;
        }
    }

    public void RollRadj()
    {
        foreach (ParticleSystem smoke in RollsR)
        {
            var StartLifeTime = smoke.main;
            StartLifeTime.startLifetime = AdjLifeTime;
        }
    }
    public void RollRclose()
    {
        foreach (ParticleSystem smoke in RollsR)
        {
            var StartLifeTime = smoke.main;
            StartLifeTime.startLifetime = 0f;
        }
    }
}
