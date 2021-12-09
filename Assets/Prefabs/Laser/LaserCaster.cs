using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCaster : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LCManager;
    public Vector3 LaserDir;
    public float Dist;
    void Start()
    {
        //LaserDir = transform.TransformDirection(Vector3.forward);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LaserDir = transform.TransformDirection(Vector3.up);
        var LaserRay = new Ray(transform.position, LaserDir);
        RaycastHit hit;

        
        if (Physics.Raycast(LaserRay,out hit, Dist))
        {
            Debug.Log(hit.transform.name);
            Debug.DrawRay(transform.position, LaserDir* hit.distance, Color.yellow);
            drawPath();
        }
        else
        {
            Debug.DrawRay(transform.position, LaserDir * Dist, Color.white);

            Debug.Log("Did not Hit");
            drawPath();
        }
    }

    void drawPath()
    {
        var lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
        lineRenderer.positionCount = 2;
        lineRenderer.SetWidth(0.5f,0.5f);
        lineRenderer.SetPosition(0, this.transform.position);
        lineRenderer.SetPosition(1, transform.position+LaserDir*Dist);
    }
}
