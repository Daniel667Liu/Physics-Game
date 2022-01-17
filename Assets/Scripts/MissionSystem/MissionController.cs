using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionController : MonoBehaviour
{

    public GameObject[] MissionPoints;//store  main missions
    public int MissionIndex = 0;//control missions order
    public string[] MissionBars;// main mission notification
    public GameObject MissionBar;
    private TMP_Text MissionText;
    public AudioSource TouchMP;

    public GameObject[] BMissionPoints;


    
    //需要在mission controller中添加ui脚本触发任务提示和当前任务目标,可能需要导航目标数组
    public bool Portal_Open = false;//开启传送门
    public bool Dead_Portal_Open;//开启死星传送门，导航目标同时设置为三个任务点
    public bool BlackHole_Open;//开启黑洞
    public BlackHole BH;
    public int bigMissionComplete =0;//记录完成了多少大任务
    //
    void Start()
    {
        MissionPoints[MissionIndex].gameObject.SetActive(true);//active the first mission point
        MissionText = MissionBar.GetComponent<TMP_Text>();
        MissionText.text = MissionBars[MissionIndex];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MissionComplete() 
    {
        //MissionPoints[MissionIndex].gameObject.SetActive(false);//先将自己关闭
/*        0: check motherland
        1: check moon
        2: check fire hole
        3: go through the Portal
        4: check greedy worm
        5: back to portal
        6: back to new portal
        7: go through the black hole*/


        if (MissionIndex < MissionPoints.Length)
        {
            //find the portal
            Debug.Log(MissionPoints[MissionIndex].gameObject.name);
            if (MissionPoints[MissionIndex].gameObject.name == "FireHoles")
            {
                Portal_Open = true;

            }
            //find dead planet
            else if (MissionPoints[MissionIndex].gameObject.name == "BioP")//if hit BioP
            {
                Dead_Portal_Open = true;
            }
            else if (MissionPoints[MissionIndex].gameObject.name == "BackPortal")
            {
                for (int i = 0; i < BMissionPoints.Length; i++)
                {
                    BMissionPoints[i].gameObject.SetActive(true);//open all the big missions
                }
                MissionIndex++;

                Portal_Open = false;
                Dead_Portal_Open = false;
            }
        }
        else
        {
            //bigMission
            for (int i = 0; i < BMissionPoints.Length; i++)
            {
                if (!BMissionPoints[i].activeSelf)
                {
                    bigMissionComplete++;
                }
            }
            if (bigMissionComplete >= 3)
            {
                BH.DESTROY = true;
            }
        }
        /*        if (MissionIndex >= 5) 
                {
                    bigMissionComplete++;
                    if (bigMissionComplete >= 3) 
                    {
                        BlackHole_Open = true;
                    }
                }*/
        if(MissionIndex<MissionPoints.Length)
        {
            MissionPoints[MissionIndex + 1].gameObject.SetActive(true);
            MissionIndex++;
            MissionText.text = MissionBars[MissionIndex];
        }

    }
}
