using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Rigidbody_Test : MonoBehaviour
{

    public Vector3 ForceUp;
    public Vector3 ForceDown;
    public Vector3 ForceLeft;
    public Vector3 ForceRight;
    public Vector3 ForceForward;
    public Vector3 ForceBackward;
    

    public float ForceStrength = 0.05f;
    public Rigidbody m_rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            m_rigidbody.AddForce(ForceUp * ForceStrength, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            m_rigidbody.AddForce(ForceDown * ForceStrength, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            m_rigidbody.AddForce(ForceLeft * ForceStrength, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            m_rigidbody.AddForce(ForceRight * ForceStrength, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.Space ))
            m_rigidbody.AddForce(ForceForward * ForceStrength, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.B))
            m_rigidbody.AddForce(ForceBackward * ForceStrength, ForceMode.Impulse);
    }
}
