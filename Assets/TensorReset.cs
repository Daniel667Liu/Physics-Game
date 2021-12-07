using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TensorReset : MonoBehaviour
{
    // Start is called before the first frame update
    public Quaternion quaternion = new Quaternion(0, 0, 0,0);
    public Vector3 MassCenter = new Vector3(0, 0, 0);
    void Start()
    {
        //GetComponent<Rigidbody>().inertiaTensorRotation = Quaternion.identity;
    }
    void ResetTensor()
    {
        //GetComponent<Rigidbody>().inertiaTensorRotation = Quaternion.identity;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        quaternion = quaternion.normalized;
        GetComponent<Rigidbody>().inertiaTensorRotation = quaternion;
        GetComponent<Rigidbody>().centerOfMass = MassCenter;
     

    }
}
