using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Picked = false;

    public GameObject Solar1OrbitController;
    public GameObject Solar2OrbitController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!Solar1OrbitController.GetComponent<OrbitDebugDisplay>().Displaying)
                Solar1OrbitController.GetComponent<OrbitDebugDisplay>().Displaying = true;
            else
                Solar1OrbitController.GetComponent<OrbitDebugDisplay>().Displaying = false;

        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag=="Item")
        {
            //picked Up
            Picked = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Destination")
        {
            //picked Up
            if(Picked)
            {
                Destroy(collision.gameObject);
            }
        }
    }


}
