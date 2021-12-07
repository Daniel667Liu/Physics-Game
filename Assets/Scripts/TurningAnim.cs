using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningAnim : MonoBehaviour
{
    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Animator.SetFloat("Yaw", Input.GetAxis("Horizontal"));
        Animator.SetFloat("Pitch", Input.GetAxis("Vertical"));
        if (Input.GetKeyDown("joystick button 4")) { Animator.SetBool("RollLeft", true); }
        if (Input.GetKeyUp("joystick button 4")) { Animator.SetBool("RollLeft", false); }
        if (Input.GetKeyDown("joystick button 5")) { Animator.SetBool("RollRight", true); }
        if (Input.GetKeyUp("joystick button 5")) { Animator.SetBool("RollRight", false); }
    }
}
