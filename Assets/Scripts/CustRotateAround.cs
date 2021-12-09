using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustRotateAround : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Center;
    public float speed;
    bool rotate = true;
    public Vector3 Dir;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(Center.transform.position);
        if (rotate)
            this.transform.RotateAround(Center.transform.position, Dir, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //rotate = false;
        }
    }
}
