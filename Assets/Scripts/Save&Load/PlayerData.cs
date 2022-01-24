using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//define that this class can be save as files
public class PlayerData //deifne a empty class to store the data, no monobehavior.
{
    public float Health;
    public float Fuel;
    public int missionIndex;
    public float[] Position;
    public float[] Rotation;
    public bool[] MusicPermissions;

    public PlayerData(Player player) //input info from player to player data
    {
        Health = player.Health;
        Fuel = player.Fuel;
        MusicPermissions = player.MusicPermissions;
        missionIndex = player.missionIndex;

        Rotation = new float[3];//store rotation into a float array
        Rotation[0] = player.Rotation.x;
        Rotation[1] = player.Rotation.y;
        Rotation[0] = player.Rotation.z;

        Position = new float[3];//store position into a float array
        Position[0] = player.Position.x;
        Position[1] = player.Position.y;
        Position[2] = player.Position.z;

        


    }
}
