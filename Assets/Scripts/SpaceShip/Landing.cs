using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landing : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isLanding = false;
    public bool isLandingBH = false;
    public GameObject Planet;
    Vector3 DirG;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isLanding)
        {
            /*            Debug.Log("Planet speed = "+Planet.GetComponent<Rigidbody>().velocity);
                        Debug.Log("Spaceship speed = " + this.GetComponent<Rigidbody>().velocity);
                        this.GetComponent<Rigidbody>().velocity += Planet.GetComponent<Rigidbody>().velocity;*/

            DirG = (Planet.transform.position - this.transform.position).normalized;
            this.GetComponent<Rigidbody>().AddForce(DirG*Planet.GetComponent<CelestialBody>().surfaceGravity/10,ForceMode.Impulse);
        }
        if(isLandingBH)
        {
            DirG = (Planet.transform.position - this.transform.position).normalized;
            this.GetComponent<Rigidbody>().AddForce(DirG*100f, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Planet")
        {
            isLanding = true;
            Planet = collision.gameObject;
            //collision.GetComponent<Rigidbody>().velocity
        }
        if (collision.gameObject.tag == "BH")
        {
            isLandingBH = true;
            Planet = collision.gameObject;
            //collision.GetComponent<Rigidbody>().velocity
        }

    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Planet")
        {
            isLanding = true;
            Planet = other.gameObject;
        }
        if (other.gameObject.tag == "BH")
        {
            isLandingBH = true;
            Planet = other.gameObject;
            //collision.GetComponent<Rigidbody>().velocity
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isLanding = false;
        isLandingBH = false;
    }
}
