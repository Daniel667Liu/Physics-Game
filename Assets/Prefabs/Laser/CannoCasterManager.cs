using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannoCasterManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float CastRateXL;
    public float CastRateM;
    float TimerXL, TimerM;
    public GameObject RockXL;
    public GameObject RockM;
    public GameObject Planet;

    public GameObject Player;
    public bool Fire = false;

    public GameObject[] CannonXLs, CannonMs;

    void Start()
    {
        TimerM = CastRateM; TimerXL = CastRateXL;
        RockXL.GetComponent<CannoCaster>().Planet = Planet;
        RockM.GetComponent<CannoCaster>().Planet = Planet;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(Vector3.Distance(Planet.transform.position, Player.transform.position));

        if(Vector3.Distance(Planet.transform.position,Player.transform.position)<400f)
        {
            Fire = true;
        }
        else
        {
            Fire = false;
        }
        if(Fire)
        {
            //Rock caster XL
            if (CastRateXL > 0)
            {
                if (TimerXL > 0)
                {
                    TimerXL -= Time.deltaTime;
                }
                if (TimerXL < 0)
                {
                    for(int i=0; i<CannonXLs.Length;i++)
                    {
                        Instantiate(RockXL, CannonXLs[i].transform.position, CannonXLs[i].transform.rotation);
                    }

                    TimerXL = CastRateXL;
                }

            }

            //Rock caster M

            if (CastRateM > 0)
            {
                if (TimerM > 0)
                {
                    TimerM -= Time.deltaTime;
                }
                if (TimerM < 0)
                {
                    for(int j=0;j<CannonMs.Length;j++)
                    {
                        Instantiate(RockM, CannonMs[j].transform.position, CannonMs[j].transform.rotation);

                    }

                    TimerM = CastRateM;
                }

            }
        }

    }
}
