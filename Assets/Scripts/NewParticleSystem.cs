using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewParticleSystem : MonoBehaviour
{
    public ParticleSystem MainFire;
    public ParticleSystem MainSmoke;
   
    private float SapceshipXSpeed;
    private float MainFireStrength;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MainFireStrength = Input.GetAxis("Forward");
        MainFireControll();
        MainSmokeControll();

    }

    public void MainFireControll() 
    {
        
        MainFire.startSpeed = -1f - (9f * MainFireStrength);
        MainFire.emissionRate = 100f + (900f * MainFireStrength);
        float ColorOpacity = 0.01f + (0.29f * MainFireStrength);
        MainFire.startColor = new Color(255, 255, 255,ColorOpacity);
       
    }

    public void MainSmokeControll() 
    {
        Vector3 CurrentPos = MainSmoke.transform.localPosition;
        MainSmoke.transform.localPosition = new Vector3(CurrentPos.x, CurrentPos.y, 1f + MainFireStrength);
        MainSmoke.startSpeed = 2f + (3f * MainFireStrength);
        MainSmoke.emissionRate = 25f + (175f * MainFireStrength);
        MainSmoke.startSize = 2f + (2f * MainFireStrength);
        
    }

}
