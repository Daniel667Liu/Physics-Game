using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isHitted;
    public float VibrationDelay = 0.5f;
    public Vector3 LargeScale;
    public Vector3 SmallScale;
   /* private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        isHitted = true;
       
    }

    /*private void OnCollisionExit(UnityEngine.Collision collision)
    {
        isHitted = false;
    }*/

    private void OnTriggerEnter(Collider other)
    {
        isHitted = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isHitted = false;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
