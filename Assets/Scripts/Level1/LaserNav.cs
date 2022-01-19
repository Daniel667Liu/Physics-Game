using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserNav : MonoBehaviour
{
    public GameObject Player;
    public MissionController MC;
    //public Vector3 LaserDir;
    //public float Dist;
    public GameObject[] Cubes;

    public GameObject Orbits;
    public bool DrawPath=false;
    public LineRenderer LR;
    void Start()
    {
        LR = this.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        /*        LaserDir = transform.TransformDirection(Vector3.up);
                var LaserRay = new Ray(transform.position, LaserDir);
                RaycastHit hit;


                if (Physics.Raycast(LaserRay, out hit, Dist))
                {
                    Debug.Log(hit.transform.name);
                    Debug.DrawRay(transform.position, LaserDir * hit.distance, Color.yellow);
                    drawPath();
                }
                else
                {
                    Debug.DrawRay(transform.position, LaserDir * Dist, Color.white);

                    Debug.Log("Did not Hit");
                    drawPath();
                }*/
/*        if(Input.GetKeyDown("joystick button 9"))
        {
            if(Orbits.activeSelf)
            {
                Orbits.SetActive(false);
            }
            else
            {
                Orbits.SetActive(true);
            }
        }
        if (Input.GetKeyDown("joystick button 3"))
        {
            Debug.Log("joystick button 3");
            if(DrawPath)
            {
                LR.enabled = false;
                DrawPath = false;
            }
            else
            {
                LR.enabled = true;
                DrawPath = true;
            }
        }

        if(DrawPath)
        {

            drawPath();
        }*/

    }
/*    void drawPath()
    {
        LR.positionCount = 2;
        LR.SetWidth(0.1f, 0.1f);
        LR.SetPosition(0, this.transform.position);
        LR.SetPosition(1, Cubes[MC.MissionIndex].transform.position);
    }*/
}
