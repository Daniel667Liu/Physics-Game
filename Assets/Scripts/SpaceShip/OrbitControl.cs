using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Orbits;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 9"))
        {
            if (Orbits.activeSelf)
            {
                Orbits.SetActive(false);
            }
            else
            {
                Orbits.SetActive(true);

            }
        }
    }
}
