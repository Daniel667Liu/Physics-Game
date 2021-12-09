using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannoCaster : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Planet;
    public Vector3 Dir;
    public float Force;
    public float DisappearDist;
    public Vector3 currentScale;
    public Vector3 scaleChange;
    void Awake()
    {
        Dir= (this.transform.position-Planet.transform.position).normalized;
        this.GetComponent<Rigidbody>().AddForce(Dir *Force, ForceMode.Impulse);
        currentScale = this.transform.localScale;
        scaleChange = currentScale / DisappearDist;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.localScale.x>0)
        {
            this.transform.localScale -= scaleChange;
        }
        else
        {
            Destroy(this.gameObject);
        }

        if (Vector3.Distance(transform.position, Planet.transform.position) > DisappearDist)
        {
            //Destroy(this.gameObject);
        }
    }
}
