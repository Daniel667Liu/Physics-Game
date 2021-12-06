using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionPoints : MonoBehaviour
{
    // Start is called before the first frame update
    public Image Point;
    public Transform PlanetTest;
    public Transform [] Planets;
    public Text Dist;
    //

    void Start()
    {

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float minX = Point.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = Point.GetPixelAdjustedRect().width / 2;
        float maxY = Screen.height - minY;
        Vector2 pos = Camera.main.WorldToScreenPoint(PlanetTest.position);
        
        if(Vector3.Dot(PlanetTest.position-transform.position,transform.forward)<0)
        {
            if(pos.x < Screen.width/2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }

        pos.x = Mathf.Clamp(pos.x,minY,maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        Point.transform.position = pos;



    }
}
