using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour //usd as an inter-storage script, obj--player--binaryfile.
{

    public GameObject SavePoint;
    public Vector3 Position;//no calls, called by trigger save point
    public Vector3 Rotation;
    public float Health;
    public float Fuel;
    public int missionIndex;
    public bool[] MusicPermissions;//no calls, called by MusicPickup.c#
    private ShipHealth shipHealth;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
