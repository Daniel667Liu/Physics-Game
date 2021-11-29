using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Destruction : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mesh;

    float cubeWidth;
    float cubeHeight;
    float cubeDepth;

    public float cubeScale = 0.3f;

    //Swithc Model
    public GameObject switchModel;
    public GameObject Fire;

    void Start()
    {
        
        cubeWidth = transform.localScale.z;
        cubeHeight = transform.localScale.y;
        cubeDepth = transform.localScale.x;

        //gameObject.GetComponent<MeshRenderer>().enabled = false;
        mesh.gameObject.GetComponent<Transform>().localScale = new Vector3(cubeScale, cubeScale, cubeScale);
    }
    void FixedUpdate()
    {
        //this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down,ForceMode.Impulse);
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //CreateCube();
            SwtichModel();
            Destroy(this.gameObject);
            Destroy(Fire);
        }
    }

    void CreateCube()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        for (float x = 0; x<cubeWidth; x+= cubeScale)
        {
            for(float y = 0; y < cubeHeight; y += cubeScale)
            {
                for(float z = 0; z < cubeDepth; z += cubeScale)
                {
                    Vector3 vec = transform.position;

                    GameObject cubes = (GameObject)Instantiate(mesh, vec + new Vector3(x, y, z), Quaternion.identity);
                    cubes.gameObject.GetComponent<MeshRenderer>().material = gameObject.GetComponent<MeshRenderer>().material;
                }
            }
        }
    }
    // Update is called once per frame
    void SwtichModel()
    {
        Instantiate(switchModel, this.transform.position, this.transform.rotation);
    }
}
