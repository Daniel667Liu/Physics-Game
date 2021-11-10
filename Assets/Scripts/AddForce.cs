using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{

    public Vector3 ForceDir;
    Rigidbody m_Rigidbody;
    public float ForceStrength;

    public GameObject StartPos;
    public GameObject EndPos;
    private Vector3 Pos1;//start of the direction vector
    private Vector3 Pos2;//end of the direction vector
    public bool is_engineStart;

    //define the dierection of the force by using a int, 1 = foward, 2 = backward, 3 = up, 4 = down, 5 = left. 6 = right.
    public bool Direction_Reverse;
    // Start is call

    public void ForceStart() 
    {
        DirectionDetermine();
        
        m_Rigidbody.AddForce(ForceDir * ForceStrength, ForceMode.Impulse);
    }

    public void  DirectionDetermine() 
    {
        Pos1 = StartPos.transform.position;
        Pos2 = EndPos.transform.position;
        ForceDir = Pos1 - Pos2;
        ForceDir.Normalize();//normalize the force dir, for add scale on it.
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
        if (is_engineStart)
            ForceStart();
    }

    
}
