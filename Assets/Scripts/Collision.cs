using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private Collider[] hitColliders;

    public float blastRadius;
    public float explosionPower;
    public LayerMask explosionLayers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(UnityEngine.Collision col)
    {
        if((col.gameObject.transform.root.CompareTag("box")))
        {
            //destroy(col.contacts[0].point);

        }
    }

    void destroy(Vector3 explosionPoint)
    {
        //hitColliders = Physics.OverlapSphere(explosionPoint, blastRadius, explosionLayers);

            foreach (Collider hitCol in hitColliders)
        {
            if(hitCol.GetComponent<Rigidbody>()==null)
            {
                hitCol.GetComponent<MeshCollider>().enabled = true;
                hitCol.gameObject.AddComponent<Rigidbody>();

                hitCol.GetComponent<Rigidbody>().mass = 2;
                hitCol.GetComponent<Rigidbody>().isKinematic = false;

                //hitCol.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward *5;
                //hitCol.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, explosionPoint, blastRadius, 1, ForceMode.Impulse);
            }
        }
    }
}
