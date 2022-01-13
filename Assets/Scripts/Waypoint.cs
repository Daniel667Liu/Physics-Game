using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Waypoint : MonoBehaviour
{
    public Image img;
    public Transform Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float minX = img.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;
        float minY = img.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;

        Vector2 pos = Camera.main.WorldToScreenPoint(Target.position);

        if(Vector3.Dot(Target.position-transform.position,transform.forward)<0)
        {
            if(pos.x<Screen.width/2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }

/*            if (pos.y < Screen.height / 2)
            {
                pos.y = maxY;
            }
            else
            {
                pos.y = minY;
            }*/
        }

        pos.x = Mathf.Clamp(pos.x,minX,maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        img.transform.position = pos;
    }
}
