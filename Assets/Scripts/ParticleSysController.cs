using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSysController : MonoBehaviour
{
    ParticleSystem sys;

    float minStartSpeed, maxStartSpeed;

    ParticleSystem.MainModule sysMain;

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
}
