using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicRadio : MonoBehaviour
{
    public GameObject MusicUI;
    public AudioSource AudioSource;
   
    //public AudioSource WarnigAudio;
    public AudioClip[] AudioClips;
    public string[] MusicNames;
    public AudioClip noPermission;
    public bool[] ClipPermissions;
    private int AUDIOindex = 0;
    private bool beginMusic = false;
    public GameObject PickupUI;

    // Start is called before the first frame update

    private void Start()
    {
        setSong(AUDIOindex);
        PickupUI.gameObject.SetActive(false);
        
        //SetMusicUI();
        
    }

    public void musicPickUp(int musicNum) 
    {
        ClipPermissions[musicNum] = true;
        PickupUI.gameObject.SetActive(true);
        PickupUI.GetComponent<TMP_Text>().text = MusicNames[musicNum];
        Invoke("HidePickUI", 5f);
    }

    private void HidePickUI() 
    {
        PickupUI.SetActive(false);
        CancelInvoke();
    }

    public void setSong(int AudioIndex) 
    {
        if (ClipPermissions[AUDIOindex])
        {
            AudioSource.volume = 1f;
            AudioSource.clip = AudioClips[AudioIndex];
        }
        else 
        {
            AudioSource.volume = 0.2f;
            AudioSource.clip = noPermission;
        }
           
    }
    public void playAudio()
    {
      
        AudioSource.Play();
        
        
       Invoke("MusicFunc", AudioSource.clip.length + 1f);
        
        
    }
    
    public void skipSong() 
    {

        if (AUDIOindex == AudioClips.Length - 1)
        {
            AUDIOindex = 0;
        }
        else 
        {
            AUDIOindex++;
        }
    }

    public void MusicFunc() 
    {
        if (!beginMusic)
        {
            AudioSource.Play();
            Invoke("MusicFunc", AudioSource.clip.length + 1f);
            beginMusic = true;
            SetMusicUI();
        }
        else 
        {
            skipSong();
            setSong(AUDIOindex);
            playAudio();
            SetMusicUI();
        }
    }

    public void SetMusicUI() 
    {
        if (ClipPermissions[AUDIOindex] == true)
        {
            MusicUI.GetComponent<TMP_Text>().text = MusicNames[AUDIOindex];
        }
        else 
        {
            MusicUI.GetComponent<TMP_Text>().text = "#MUSIC#NOT#COLLECTED#";
            
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("joystick button 1")) 
        {
            CancelInvoke();
            MusicFunc();
            
        }
    }
}
