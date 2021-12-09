using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_SelfRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Planet;
    public float speedX, speedY, speedZ;
    bool rotate = true;
    Vector3 DirG;
    public GameObject BlackHole;

    public int Destroy = 0;
    void Start()
    {
        BlackHole = GameObject.FindGameObjectWithTag("BH");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DirG=(BlackHole.transform.position - this.transform.position).normalized;
        if (!BlackHole.GetComponent<BlackHole>().DESTROY)
        this.transform.Rotate(speedX * Time.deltaTime, speedY * Time.deltaTime, speedZ * Time.deltaTime, Space.Self);
        else
        {
            //this.GetComponent<Rigidbody>().AddForce(DirG * Random.Range(10f, 150f), ForceMode.Impulse);
        }

        if (BlackHole.GetComponent<BlackHole>().DESTROY)
        {
            Destroy++;
            if (Destroy == 3)
            {
                Destroy = 2;
            }
        }
        if (Destroy == 1)
        {
            this.GetComponent<Rigidbody>().AddForce(DirG * Random.Range(10f, 150f), ForceMode.Impulse);
        }

        if (Vector3.Distance(BlackHole.transform.position, this.transform.position) < 100f)
        {
            Destroy(this.gameObject);
        }
    }

}
