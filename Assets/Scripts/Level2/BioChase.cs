using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BioChase : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Center;
    public float speed;
    bool rotate = true;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Transform pos = Center.transform;
        this.transform.RotateAround(pos.position, Vector3.up, speed * Time.deltaTime);
    }
}
