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

    public Text meter;
    public Vector3 offset;


    //
    public int MissionIndex = 0;
    void Start()
    {

    void Update()
    {
        // Giving limits to the icon so it sticks on the screen
        // Below calculations witht the assumption that the icon anchor point is in the middle
        // Minimum X position: half of the icon width
        float minX = Point.GetPixelAdjustedRect().width / 2;
            // Maximum X position: screen width - half of the icon width
            Debug.Log(minX);
        float maxX = Screen.width - minX;
        // Minimum Y position: half of the height
        float minY = Point.GetPixelAdjustedRect().height / 2;
            Debug.Log(minY);
            // Maximum Y position: screen height - half of the icon height
            float maxY = Screen.height - minY;

        // Temporary variable to store the converted position from 3D world point to 2D screen point
        Vector2 pos = Camera.main.WorldToScreenPoint(PlanetTest.position);

        // Check if the target is behind us, to only show the icon once the target is in front
        if (Vector3.Dot((PlanetTest.position - transform.position), transform.forward) < 0)
        {
            // Check if the target is on the left side of the screen
            if (pos.x < Screen.width / 2)
            {
                // Place it on the right (Since it's behind the player, it's the opposite)
                pos.x = maxX;
            }
            else
            {
                // Place it on the left side
                pos.x = minX;
            }
        }

        // Limit the X and Y positions
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

            // Update the marker's position
            Point.transform.position = pos;
        // Change the meter text to the distance with the meter unit 'm'
        meter.text = ((int)Vector3.Distance(PlanetTest.position, transform.position)).ToString() + "m";
    }

        Dist.text = Vector3.Distance(this.transform.position, Planets[MissionIndex].position).ToString();

    }
}

