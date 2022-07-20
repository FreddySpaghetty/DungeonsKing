using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;

public class AfterDeathManager
{
    public static AfterDeathManager instance;
    public static void Save (PlayerManager player, PlayerCombact playercombact,ScoreScript scorescript)
    {
        BinaryFormatter form = new BinaryFormatter();
        string path = Application.persistentDataPath + "/memory.card";
        FileStream stream = new FileStream(path,FileMode.Create);
        SaveDataStructure data = new SaveDataStructure(player,playercombact,scorescript);
        Debug.Log("att   "+  data.attack);
        Debug.Log("sped   "+  data.speed);
        Debug.Log("score   "+  data.score);
        Debug.Log("health   "+  data.health);
        form.Serialize(stream,data);
        stream.Close();
    }
    public static SaveDataStructure Load ()
    {
        string path = Application.persistentDataPath + "/memory.card";
        if (File.Exists(path))
        {
            BinaryFormatter form = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveDataStructure data = form.Deserialize(stream) as SaveDataStructure;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log(path + " Save File not found");
            return null;

        }
    }





}
