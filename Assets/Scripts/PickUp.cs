using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Picked = false;

    public GameObject MainCam;
    public int onMissionIndex = 0;
    //
    public GameObject Orbits;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 9"))
        {
            Debug.Log("button down");
            if(!Orbits.activeSelf)
            {
                Orbits.SetActive(true);
            }
            else
            {
                Orbits.SetActive(false);
            }
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
