using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    // Start is called before the first frame update
    public ShipHealth HP;
    public bool TakeDam = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TakeDam)
        {
            HP.health -=2f* Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            TakeDam = true;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            TakeDam = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        TakeDam = false;
    }
}
