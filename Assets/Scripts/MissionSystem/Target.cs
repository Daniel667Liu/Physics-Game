using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MissionController;
    Transform HUDPivot;
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
        if(other.gameObject.name== "ShipWithTrail")
        {
            Debug.Log(other.gameObject.name);
            MissionController.GetComponent<MissionController>().MissionComplete();
            this.gameObject.GetComponent<MeshRenderer>().enabled=false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            HUDPivot.gameObject.SetActive(false);
        }
/*        if (other.gameObject.name == "Detector")
        {
            Transform HUDPivot;

            HUDPivot.gameObject.SetActive(true);
        }*/
    }

}
