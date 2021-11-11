using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    
    public AddForce Engine;
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
            Engine.is_engineStart = true;
        }
    }
    private void OnTriggerExit(Collider Player)
    {

        if (Player.gameObject.tag == "Player")
        {
            Engine.is_engineStart  = false;
        }
    }
}
