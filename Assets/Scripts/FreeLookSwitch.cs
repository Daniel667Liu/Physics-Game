using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FreeLookSwitch : MonoBehaviour
{

    
    public CinemachineFreeLook TargetFreeLook;
    private bool isRightControl = true;

    public void RightControl() 
    {
        
        TargetFreeLook.m_YAxis.m_InputAxisName = "Mouse Y";
        TargetFreeLook.m_XAxis.m_InputAxisName = "Mouse X";
        isRightControl = true;
    }

    public void LeftControl()
    {
        TargetFreeLook.m_YAxis.m_InputAxisName = "Vertical";
        TargetFreeLook.m_XAxis.m_InputAxisName = "Roll";
        isRightControl = false;
    }

    public void CameraControllSwitch() 
    {
        if (isRightControl)
        {
            LeftControl();
        }

        else 
        {
            RightControl();
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
