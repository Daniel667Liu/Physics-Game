using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public GameObject Locked, Unlock;
    public MissionController MC;
    void Start()
    {
        Locked.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(MC.Portal_Open)
        {
            Unlock.SetActive(true);
            Locked.SetActive(false);

            Destroy(this.gameObject);
        }
    }
}
