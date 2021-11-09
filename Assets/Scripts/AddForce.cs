using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{

    public Vector3 ForceDir;
    Rigidbody m_Rigidbody;
    // Start is called before the first frame update


    public void ForceStart() 
    {
        m_Rigidbody.AddForce(ForceDir, ForceMode.Impulse);
    }

    private void OnMouseDown()
    {
        ForceStart();
    }
    void Start()
    {
      m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
