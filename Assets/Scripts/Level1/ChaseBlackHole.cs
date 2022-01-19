using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBlackHole : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BlackHole;
    Vector3 DirG;
    public int DestroyCount = 0;
    void Start()
    {
        DirG = (BlackHole.transform.position - this.transform.position).normalized;
        //this.GetComponent<Rigidbody>().AddForce(DirG * Random.Range(1f, 200f), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //this.GetComponent<Rigidbody>().AddForce(DirG * Random.Range(1f, 2f), ForceMode.Impulse);
        if(DestroyCount<1)
        {
            if(BlackHole.GetComponent<BlackHole>().DESTROY)
            {
                this.GetComponent<Rigidbody>().AddForce(DirG * Random.Range(1f, 300f), ForceMode.Impulse);
                DestroyCount++;
            }
            
        }

        if (Vector3.Distance(BlackHole.transform.position, this.transform.position) < 300f)
        {
            Destroy(this.gameObject);
        }


/*        if (BlackHole.GetComponent<BlackHole>().DESTROY)
        {
            DestroyCount++;
            if(DestroyCount == 3)
            {
                DestroyCount = 2;
            }
        }
        if(DestroyCount == 1)
        {
            this.GetComponent<Rigidbody>().AddForce(DirG * Random.Range(1f, 300f), ForceMode.Impulse);
        }
        if (Vector3.Distance( BlackHole.transform.position,this.transform.position)<100f)
        {
            Destroy(this.gameObject);
        }*/
    }
}
