using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    public bool controlButton = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider Player)
    {
        if(Player.gameObject.tag == "Player")
        {
            controlButton = true;
        }
    }
    private void OnTriggerExit(Collider Player)
    {

        if (Player.gameObject.tag == "Player")
        {
            controlButton = false;
        }
    }
}
