using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MaterialChange : MonoBehaviour
{
    public Material targetMat;//the meterial mesh useing
    public MeshRenderer mesh;//assign dissolve shader for the material

    public void MatChange() //when changing the material, need to change the shader first, then bedign to dissolve.
    {
        mesh.material = targetMat;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
