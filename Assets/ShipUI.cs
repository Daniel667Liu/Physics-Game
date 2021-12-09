using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShipUI : MonoBehaviour
{
    public GameObject ship;
    public GameObject SpeedUI;
    public GameObject HealthUI;
    public GameObject FuelUI;
    private ShipHealth ShipHealthScript;
    //public ShipHealth shipInfo;
    // Start is called before the first frame update
    void Start()
    {
        ShipHealthScript = FindObjectOfType<ShipHealth>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int speed = (int)(ship.GetComponent<Rigidbody>().velocity.magnitude *6.5f);
        SpeedUI.GetComponent<TMP_Text>().text = speed.ToString();
        int health =(int) ShipHealthScript.health;
        HealthUI.GetComponent<TMP_Text>().text = health.ToString();
        int fuelVolume = (int)ShipHealthScript.fuel;
        FuelUI.GetComponent<TMP_Text>().text = fuelVolume.ToString();
    }
}
