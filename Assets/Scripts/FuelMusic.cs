using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelMusic : MonoBehaviour
{

    public GameObject self;
    private ShipHealth ship;
    private MusicRadio musicradio;
    private string TAG;
    public int MusicIndex;


    void Start()
    {
        TAG = self.gameObject.tag;
        ship = FindObjectOfType<ShipHealth>();
        musicradio = FindObjectOfType<MusicRadio>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            if (TAG == ("Fuel"))
            {
                ship.Charge();//charge the ship
            }
            else if (TAG == ("Music")) 
            {
                musicradio.ClipPermissions[MusicIndex] = true;//get the music
            }
        }
        
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
