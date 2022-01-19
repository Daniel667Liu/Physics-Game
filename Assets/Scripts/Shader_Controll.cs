using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shader_Controll : MonoBehaviour
{
    public Material[] DissolveMAT;
    public float Dissolve_Speed = 0.01f;//Difine the speed of shader lerping , 0.1f - 1f.
    public bool Dissolve_Start;//begin to dissolve?
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShaderLerp() 
    {
        if (Dissolve_Start) 
        {
            for (int i = 0; i< DissolveMAT.Length; i++) 
            {
                float a = Mathf.Lerp(DissolveMAT[i].GetFloat("_strength"), 1f, Dissolve_Speed);
                DissolveMAT[i].SetFloat("_strength", a);

                if (a > 0.9) //dissolve end.
                {
                    Dissolve_Start = false;
                }

                Debug.Log(a);// for test
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) //for test, key down
        {
            Dissolve_Start = true;
        }

        ShaderLerp();
    }
}
