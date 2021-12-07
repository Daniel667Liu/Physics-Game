using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Picked = false;

    public GameObject MainCam;
    public int onMissionIndex = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {

        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag=="Item"&& onMissionIndex== MainCam.GetComponent<MissionPoints>().MissionIndex)
        {
            //picked Up
            onMissionIndex+=1;
            MainCam.GetComponent<MissionPoints>().MissionIndex+=1;
            Picked = true;
            collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
        }

    }


}
