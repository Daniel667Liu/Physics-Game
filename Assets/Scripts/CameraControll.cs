using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControll : MonoBehaviour
{
    public CinemachineFreeLook PiolitCam;
    public CinemachineFreeLook FreelookCam;
    private float mouseX;
    private float mouseY;


    public void CameraSwitch()
    {
        if ((Mathf.Abs(mouseX) + Mathf.Abs(mouseY)) > 0.1)//if the add up of two axis value is greater than 0.5 (abs) 
        {
            if (FreelookCam.Priority == 0 )
            { FreelookCam.Priority = 2; }
        }
        else 
        {
            if (-1<FreelookCam.m_XAxis.Value && FreelookCam.m_XAxis.Value < 1 && 0.48 < FreelookCam.m_YAxis.Value && FreelookCam.m_YAxis.Value < 0.52)
            {
                if (FreelookCam.Priority == 2)
                { FreelookCam.Priority = 0; }
            
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PiolitCam.Priority = 1;
        FreelookCam.Priority = 0;//initially run the follow camera, freelook stand by.
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        CameraSwitch();
    }
}
