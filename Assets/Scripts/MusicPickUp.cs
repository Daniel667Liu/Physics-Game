using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPickUp : MonoBehaviour
{
    //ÿ����Ƭ����Ҫ�Ҵ˽ű���ȷ������һ�׸豻�ҵ�
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
