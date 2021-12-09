using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TakeScreenshot : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 6"))
        {
            ScreenCapture.CaptureScreenshot(Application.dataPath + "/screenshot"+ System.DateTime.Now.ToString("yyyyMMdd_Hmmssff")+".png");
        }
    }
}
