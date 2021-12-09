using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPickUp : MonoBehaviour
{
    //每个唱片上需要挂此脚本来确定是哪一首歌被找到
    public int MusicNum;
    public MusicRadio music;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void MusicPickup() 
    {
        music.musicPickUp(MusicNum);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
