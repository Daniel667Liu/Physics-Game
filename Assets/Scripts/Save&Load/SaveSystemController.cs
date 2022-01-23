using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystemController : MonoBehaviour
{
    private Player player;
    private ShipHealth ShipHealth;
    private MusicRadio musicRadio;
    //public GameObject SavePoint;
    public GameObject SpaceShip;
    public GameObject[] Engines;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();//find the Player.cs in scene.
        ShipHealth = FindObjectOfType<ShipHealth>();
        musicRadio = FindObjectOfType<MusicRadio>();
        player.Position = player.SavePoint.GetComponent<Transform>().position;
        player.Rotation = player.SavePoint.GetComponent<Transform>().rotation.ToEuler();
    }

    public void Save() 
    {
        player.Health = ShipHealth.health;//save spaceship info into player.cs
        player.Fuel = ShipHealth.fuel;
        
        SaveSystem.SavePlayer(player);//save the player into a binary file
    }

    public void Load()
    {
        PlayerData data = SaveSystem.LoadPlayer();//read data from saved binary files
        ShipHealth.health = data.Health;
        ShipHealth.fuel = data.Fuel;

        Vector3 position;//create a vector to extract the position info from PlayerDate
        position.x = data.Position[0];
        position.y = data.Position[1];
        position.z = data.Position[2];

        Vector3 rotation;
        rotation.x = data.Rotation[0];
        rotation.y = data.Rotation[1];
        rotation.z = data.Rotation[2];

        SpaceShip.GetComponent<Transform>().position = position;
        SpaceShip.GetComponent<Transform>().rotation = Quaternion.Euler(rotation);
        
        musicRadio.ClipPermissions = data.MusicPermissions;

        for (int i = 0; i < Engines.Length; i++) //shut down the engines
        {
            Engines[i].GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        }
    }

    // Update is called once per frame
    void Update()//used for testing, use keydown
    {
        if (Input.GetKeyDown(KeyCode.O)) 
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            Load();
        }
    }
}
