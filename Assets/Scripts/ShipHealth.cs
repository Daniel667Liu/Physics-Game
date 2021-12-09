using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    public float health = 100f;
    public float fuel = 100f;
    public float fuelCharge = 40f;
    public float fuelcutRate = 0.1f;//how fast the fuel is running out
    public float damageRate = 0.1f;
    public GameObject ShipMain;
    
    private float shipSpeed;
    private Vector3 MeteoV;
    private float GasStrength;
    
   
    // Start is called before the first frame update

    public void Charge() 
    {
        if (fuel + fuelCharge >= 100)
        {
            fuel = 100f;
        }
        else 
        {
            fuel = fuel + fuelCharge;
        }
    }

    public void FuelCut(float gas_strength) 
    {
       
        fuel = fuel - fuelcutRate * GasStrength;//bond with the speed with ship

    }
    //called when get hitted, input meteorite speed  
    public void Damage(Vector3 MeteoriteSpeed) 
    {

        health = health - ((ShipMain.GetComponent<Rigidbody>().velocity - MeteoriteSpeed).magnitude * damageRate);//relative speed* damage rate
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.TryGetComponent(out Rigidbody R))
        {
            MeteoV = R.GetComponent<Rigidbody>().velocity;
            
        }
        else 
        {
            MeteoV = new Vector3(0, 0, 0);
        }
        Damage(MeteoV);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shipSpeed = ShipMain.GetComponent<Rigidbody>().velocity.magnitude;
        GasStrength = Input.GetAxis("Forward") + Input.GetAxis("Backward");
        FuelCut(GasStrength);
       
    }
}
