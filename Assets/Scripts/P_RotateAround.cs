using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_RotateAround : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Center;
    public GameObject Planet;
    public float speed;
    bool rotate = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotate)
            this.transform.RotateAround(Center.transform.position, Vector3.up, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rotate = false;
        }
    }
}
