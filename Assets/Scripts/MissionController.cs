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
    
    //��Ҫ��mission controller�����ui�ű�����������ʾ�͵�ǰ����Ŀ��,������Ҫ����Ŀ������
    public bool Portal_Open = false;//����������
    public bool Dead_Portal_Open;//�������Ǵ����ţ�����Ŀ��ͬʱ����Ϊ���������
    public bool BlackHole_Open;//�����ڶ�
    private int bigMissionComplete =0;//��¼����˶��ٴ�����
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
        //MissionPoints[MissionIndex].gameObject.SetActive(false);//�Ƚ��Լ��ر�

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
