using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewParticleSystem : MonoBehaviour
{
    public ParticleSystem MainFire;
  
    public GameObject[] SmallFires;
    
    private float SapceshipXSpeed;
    private float MainFireStrength;
    public float SmallFireStrength = 1.5f;
    private ShipTransform Shiptransform;
    private bool isShipSmall;
    private float ParticleStrengtDelta = 3f;
    private float ParticleEmmisionDelta = 400f;

    // Start is called before the first frame update
    void Start()
    {
        SmallFires = GameObject.FindGameObjectsWithTag("SmallFire");
        Shiptransform = FindObjectOfType<ShipTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isShipSmall = Shiptransform.isSmall;
        if (!isShipSmall) 
        {
            ParticleStrengtDelta = 3f;
            ParticleEmmisionDelta = 400f;
        }
        else 
        {
            ParticleStrengtDelta = 9f;
            ParticleEmmisionDelta = 900f;
        }
        MainFireStrength = Input.GetAxis("Forward");
        MainFireControll();
       
        SmallFireControl();

    }

    public void SmallFireControl() 
    {
        for (int i = 0; i < SmallFires.Length; i++) 
        {
            SmallFires[i].GetComponent<ParticleSystem>().startSpeed = -1f - (SmallFireStrength * MainFireStrength);

        }
    }

    public void MainFireControll() 
    {
        
        MainFire.startSpeed = -1f - (ParticleStrengtDelta * MainFireStrength);
        MainFire.emissionRate = 100f + (ParticleEmmisionDelta * MainFireStrength);
        float ColorOpacity = 0.01f + (0.29f * MainFireStrength);
        MainFire.startColor = new Color(255, 255, 255,ColorOpacity);
       
    }

   

}
