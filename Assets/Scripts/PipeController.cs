using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Rings;
    private int i = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowandDes() 
    {     
        Rings[i + 1].SetActive(true);
        Destroy(Rings[i]);
        i++;
    }

   
}
