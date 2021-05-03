using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// A class which can save and load data with. Any saved data must contain types only of:
/// int, float, string, array, bool and must be [System.Serializable]. Example:
/// [System.Serializable]
/// Public class Data {
/// ...
/// }
/// Based on https://www.youtube.com/watch?v=XOjd_qU2Ido&ab_channel=Brackeys
/// </summary>
public class SaveSystem
{
    public static void SaveData(object data, string name)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/" + name + ".saf";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static object LoadData(string name)
    {
        string path = Application.persistentDataPath + "/" + name + ".saf";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            object data = (object)formatter.Deserialize(stream);

            stream.Close();

            return data;
        } else
        {
            throw new System.Exception("File does not exist: " + name);
        }
    }
}
