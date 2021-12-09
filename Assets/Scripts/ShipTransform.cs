using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipTransform : MonoBehaviour
{
    public Rigidbody ShipMain;
    
    
    public Animator ShipAnimator;
    public bool isSmall;
    private ShipControll ShipControll;
    public float Small_F;
    public float Small_P;
    public float Small_R;
    public float Small_Y;
    public float Small_MaxTimes;
    public float Large_F;
    public float Large_P;
    public float Large_R;
    public float Large_Y;
    public float Large_MaxTimes;
    public TrailRenderer[] Trails;
    public GameObject ShipCollider;
    private ShipHealth FuelScript;
    private ShipCollider ColliderScript;
    

    // Start is called before the first frame update
    void Start()
    {
        ShipControll = FindObjectOfType<ShipControll>();
        ColliderScript = ShipCollider.GetComponentInChildren<ShipCollider>();
        FuelScript = FindObjectOfType<ShipHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 0")) 
        {
            if (isSmall)
            {
                ShipAnimator.SetBool("isSmall", false);
                isSmall = false;
                //ShiptoLarge();
            }
            else 
            {
                ShipAnimator.SetBool("isSmall", true);
                isSmall = true;
                //ShipToSmall();
            }
        }
    }

    public void ShipToSmall() 
    {
        //play the animation
        ShipControll.ForwardStrength = Small_F;//set the force ability
        ShipControll.PitchStrength = Small_P;
        ShipControll.RollStrength = Small_R;
        ShipControll.YawStrength = Small_Y;
        ShipControll.MaxForceTimes = Small_MaxTimes;
        ShipCollider.transform.localScale = (ColliderScript.SmallScale);
        FuelScript.fuelcutRate = 0.0025f;
        for (int i = 0; i <= Trails.Length-1; i++) 
        {
            Trails[i].time = 5f;
        }

    }

    public void ShiptoLarge() 
    {
        
        ShipControll.ForwardStrength = Large_F;//set the force ability
        ShipControll.PitchStrength = Large_P;
        ShipControll.RollStrength = Large_R;
        ShipControll.YawStrength = Large_Y;
        ShipControll.MaxForceTimes = Large_MaxTimes;
        ShipCollider.transform.localScale = (ColliderScript.LargeScale);
        FuelScript.fuelcutRate = 0.0015f;
        for (int i = 0; i <= Trails.Length-1; i++)
        {
            Trails[i].time = 0f;
        }

    }


}
