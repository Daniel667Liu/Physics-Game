using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPortalOpen : MonoBehaviour
{
    public GameObject DeadLocked;
    public MissionController MC;
    void Start()
    {
        DeadLocked.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(MC.Dead_Portal_Open)
        {
            DeadLocked.SetActive(false);
        }
    }
}
