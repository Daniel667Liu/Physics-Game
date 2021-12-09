using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MissionPoints : MonoBehaviour
{
    // Start is called before the first frame update
    public Image Point;
    public Transform PlanetTest;
    public Transform [] Planets;
    public TMP_Text Dist;
    //
    public int MissionIndex = 0;
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
        Vector2 pos = Camera.main.WorldToScreenPoint(Planets[MissionIndex].position);
        
        if(Vector3.Dot(Planets[MissionIndex].position - transform.position,transform.forward)<0)
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
