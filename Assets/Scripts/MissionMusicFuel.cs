using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionMusicFuel : MonoBehaviour
{
    //the script should be attached at the ship trigger

    //mission:mission需要按照顺序触发和销毁，需要建立数组依次active，确定mission发生的顺序和并行的顺序
    //mission的触发顺序按照mission脚本的函数触发
    //记录已经完成的任务
    //music：传递int值，按照int值解锁音乐文件
    //fuel：增加飞船燃料
    private MissionController missionController;//获取任务控制器，追踪任务进度
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
        missionController = FindObjectOfType<MissionController>();//游戏开始时获取任务控制器
        ShipHealth = FindObjectOfType<ShipHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
