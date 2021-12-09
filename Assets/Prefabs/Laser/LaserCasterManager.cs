using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerCasterManager : MonoBehaviour
{
    public GameObject[] Lasers;
    public float ShootRate;
    public int LaserIndex;
    public Vector3 LaserDir;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var LaserRay = new Ray(transform.position, LaserDir);
        Physics.Raycast(LaserRay);
    }

}
