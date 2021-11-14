using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSysController : MonoBehaviour
{
    public ParticleSystem sys;

    public float StartLifeTime, Zero;

    ParticleSystem.MainModule sysMain;

    public ParticleSystem [] RollsL;
    public ParticleSystem[] RollsR;
    public ParticleSystem [] MovesF;
    public ParticleSystem [] PitchesU;
    public ParticleSystem[] PitchesD;
    public ParticleSystem [] YawsL;
    public ParticleSystem[] YawsR;

    private void OnEnable()
    {
        sysMain = sys.main;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveF()
    {
        foreach (ParticleSystem smoke in MovesF)
        {
            var StartLifeTime = smoke.main;
            StartLifeTime.startLifetime = 0.4f;
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
            StartLifeTime.startLifetime = 2f;
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
            StartLifeTime.startLifetime = 2f;
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
            StartLifeTime.startLifetime = 2f;
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
            StartLifeTime.startLifetime = 2f;
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
            StartLifeTime.startLifetime = 2f;
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
            StartLifeTime.startLifetime = 2f;
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
