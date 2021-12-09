using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BioPlanet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject P_Final;
    Vector3 DirG;
    void Start()
    {
        DirG = (P_Final.transform.position - this.transform.position).normalized;
        this.GetComponent<Rigidbody>().AddForce(DirG*10, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
