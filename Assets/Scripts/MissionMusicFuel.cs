using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionMusicFuel : MonoBehaviour
{
    //the script should be attached at the ship trigger

    //mission:mission��Ҫ����˳�򴥷������٣���Ҫ������������active��ȷ��mission������˳��Ͳ��е�˳��
    //mission�Ĵ���˳����mission�ű��ĺ�������
    //��¼�Ѿ���ɵ�����
    //music������intֵ������intֵ���������ļ�
    //fuel�����ӷɴ�ȼ��
    private MissionController missionController;//��ȡ�����������׷���������
    private ShipHealth ShipHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mission")) { missionController.MissionComplete(); }
        if (other.CompareTag("Music")) 
        {
            other.gameObject.TryGetComponent(out MusicPickUp M);
            M.MusicPickup();
        }
        if (other.CompareTag("Fuel")) 
        {
            ShipHealth.Charge();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Mission") || other.CompareTag("Music") || other.CompareTag("Fuel")) 
        {
            other.gameObject.SetActive(false);
        }
    }

    void Start()
    {
        missionController = FindObjectOfType<MissionController>();//��Ϸ��ʼʱ��ȡ���������
        ShipHealth = FindObjectOfType<ShipHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
