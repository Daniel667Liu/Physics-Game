using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPickUp : MonoBehaviour
{
    //ÿ����Ƭ����Ҫ�Ҵ˽ű���ȷ������һ�׸豻�ҵ�
    public int MusicNum;
    public MusicRadio music;
    private Player player;//used for saving system.
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }
    public void MusicPickup() 
    {
        music.musicPickUp(MusicNum);
        player.MusicPermissions = music.ClipPermissions;//everytime pick up, trans permission data to /player/.
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
