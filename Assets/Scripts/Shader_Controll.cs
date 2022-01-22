using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shader_Controll : MonoBehaviour
{
    public Material[] DissolveMAT;//store the dissolve shaders, including the changing one.
    public float Dissolve_Speed = 0.01f;//Difine the speed of shader lerping , 0.1f - 1f.
    public bool Dissolve_Start;//begin to dissolve?
    private MaterialChange materialChange;
    private bool MatChanged;
    public Animator Animator;//define the aimator controlling planets shining
    // Start is called before the first frame update
    void Start()
    {
        materialChange = FindObjectOfType<MaterialChange>();
    }

    public void ShaderLerp() 
    {
        if (Dissolve_Start) 
        {
            for (int i = 0; i< DissolveMAT.Length; i++) 
            {
                float a = Mathf.Lerp(DissolveMAT[i].GetFloat("_strength"), 1f, Dissolve_Speed);
                DissolveMAT[i].SetFloat("_strength", a);

                if (a > 0.8) //dissolve end.
                {
                    Dissolve_Start = false;
                    Animator.SetBool("Scarllet", true);
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
            if (!MatChanged)//change the mat first
            {
                materialChange.MatChange();
                MatChanged = true;
            }
            Dissolve_Start = true;//begin to dissolve
            
        }

        ShaderLerp();
    }
}
