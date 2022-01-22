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
    public List<GameObject> TemFuel;
    private Player player;//used for save fuel collected.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mission")) 
        {
            missionController.MissionComplete();
            other.gameObject.SetActive(false);

        }
        if (other.CompareTag("Music")) 
        {
            other.gameObject.TryGetComponent(out MusicPickUp M);
            M.MusicPickup();
            other.gameObject.SetActive(false);

        }
        if (other.CompareTag("Fuel")) 
        {
            ShipHealth.Charge();
            
            other.gameObject.SetActive(false);
            TemFuel.Add(other.gameObject);//temrarily store collected fuel
        }

    }

    public void GameSave() //call when the game save, clear TemFuel
    {
        TemFuel.Clear();
    }

    public void GameLoad() //call when the game load, activate all fuels in TemFuel
    {
        for (int i = 0; i < TemFuel.Count; i++) 
        {
            TemFuel[i].SetActive(true);
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
