using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_SelfRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Planet;
    public float speedX, speedY, speedZ;
    bool rotate = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rotate)
        this.transform.Rotate(speedX * Time.deltaTime, speedY * Time.deltaTime, speedZ * Time.deltaTime, Space.Self);
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            rotate = false;
        }
    }
}
