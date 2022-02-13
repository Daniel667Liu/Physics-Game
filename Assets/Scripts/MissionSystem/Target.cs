using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MissionController;
    public GameObject SS;
    public GameObject SavePoint;
    public Transform HUDPivot;
    void Start()
    {
        HUDPivot = this.gameObject.transform.Find("HUDPivot");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name== "ShipWithTrail"&&this.gameObject.tag=="MissionPoint")
        {
            SS.GetComponent<Player>().SavePoint = SavePoint;
            SS.GetComponent<SaveSystemController>().Save();
            Debug.Log(this.gameObject.tag);
            MissionController.GetComponent<MissionController>().MissionComplete();
            this.gameObject.GetComponent<MeshRenderer>().enabled=false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            HUDPivot.gameObject.SetActive(false);


        }
        else if(other.gameObject.name == "ShipWithTrail" && this.gameObject.tag == "BigMission")
        {
            Debug.Log(this.gameObject.tag);
            SS.GetComponent<Player>().SavePoint = SavePoint;
            SS.GetComponent<SaveSystemController>().Save();
            MissionController.GetComponent<MissionController>().bigMissionComplete++;
            MissionController.GetComponent<MissionController>().MissionComplete();
            this.gameObject.SetActive(false);
            
        }
/*        if (other.gameObject.name == "Detector")
        {
            Transform HUDPivot;

            HUDPivot.gameObject.SetActive(true);
        }*/
    }

}
