using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_RotateAround : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Center;
    public GameObject Planet;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Planet.transform.RotateAround(Center.transform.position, Vector3.up, speed * Time.deltaTime);

    }
}
