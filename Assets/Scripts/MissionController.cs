using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionController : MonoBehaviour
{

    public GameObject[] MissionPoints;//store all missions
    public GameObject[] BMissionPoints;
    public string[] MissionBars;
    public int MissionIndex = 0;//control missions order
    public GameObject MissionBar;
    private TMP_Text MissionText;
    
    //需要在mission controller中添加ui脚本触发任务提示和当前任务目标,可能需要导航目标数组
    public bool Portal_Open = false;//开启传送门
    public bool Dead_Portal_Open;//开启死星传送门，导航目标同时设置为三个任务点
    public bool BlackHole_Open;//开启黑洞
    private int bigMissionComplete =0;//记录完成了多少大任务
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

        if (MissionIndex < 4)
        {
            
            MissionPoints[MissionIndex + 1].gameObject.SetActive(true);
            if (MissionIndex == 2)
            {
                Portal_Open = true;
            }
        }
        if (MissionIndex == 4) 
        {
            Dead_Portal_Open = true;
            for (int i = 0; i < BMissionPoints.Length; i ++) 
            {
                BMissionPoints[i].gameObject.SetActive(true);//open all the big missions
            }
        }
        if (MissionIndex >= 5) 
        {
            bigMissionComplete++;
            if (bigMissionComplete >= 3) 
            {
                BlackHole_Open = true;
            }
        }
        
        MissionIndex++;
        MissionText.text = MissionBars[MissionIndex];
    }
}
