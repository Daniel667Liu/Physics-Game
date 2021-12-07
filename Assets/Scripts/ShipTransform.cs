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

    // Start is called before the first frame update
    void Start()
    {
        ShipControll = FindObjectOfType<ShipControll>();
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
        

    }

    public void ShiptoLarge() 
    {
        
        ShipControll.ForwardStrength = Large_F;//set the force ability
        ShipControll.PitchStrength = Large_P;
        ShipControll.RollStrength = Large_R;
        ShipControll.YawStrength = Large_Y;
        ShipControll.MaxForceTimes = Large_MaxTimes;
        Debug.Log(Large_F);
       
    }


}
