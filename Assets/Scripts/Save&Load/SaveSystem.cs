using System.IO;//used for writing and reading system
using System.Runtime.Serialization.Formatters.Binary;//used for convert data to binary files 
using UnityEngine;

public static class SaveSystem //non-instanciatable class, for not creating multi-version.
{
    public static void SavePlayer(Player player) 
    {
        BinaryFormatter formatter = new BinaryFormatter();//declare a new binary formatter.
        string path = Application.persistentDataPath + "/player.daniel";//create the file path
        FileStream stream = new FileStream(path, FileMode.Create);
        //using filestreaming to creat a new file.

        PlayerData data = new PlayerData(player);
        //input info of player into file. get the info when form the PlayerData class

        formatter.Serialize(stream, data);
        //switch file info into binary format.
        stream.Close();
        //close the file stream after use.
    }

    public static PlayerData LoadPlayer() 
    {
        string path = Application.persistentDataPath + "/player.daniel";
        if (File.Exists(path)) //check if the file exists
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else 
        {
            return null;//need excute more function after, eg.deactivate the load UI
        }
    }
}
