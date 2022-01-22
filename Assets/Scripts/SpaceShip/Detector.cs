using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Detector : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject [] MissionPoints;
    public GameObject MissionController;
    public GameObject CurMissionPoint;
    public Transform CurHUDPivot;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MissionController.GetComponent<MissionController>().MissionIndex<MissionPoints.Length)
        {
            CurMissionPoint = MissionPoints[MissionController.GetComponent<MissionController>().MissionIndex];
            if (Vector3.Distance(CurMissionPoint.transform.position, this.transform.position) < 200f)
            {
                CurHUDPivot = CurMissionPoint.transform.Find("HUDPivot");
                CurHUDPivot.gameObject.SetActive(true);
            }
        }

    }

 /*   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MissionPoint")
        {
            Transform HUDPivot;
            HUDPivot = other.gameObject.transform.Find("HUDPivot");
            HUDPivot.gameObject.SetActive(true);
        }
    }*/

}
