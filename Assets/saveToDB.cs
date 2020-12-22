using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class saveToDB
{
    public static void SaveData (ChristmasClicker game)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        LocalDB localDatabase = new LocalDB(game);

        formatter.Serialize(stream, localDatabase);
        stream.Close();
    }

    public static LocalDB LoadData ()
    {
        string path = Application.persistentDataPath + "/game.txt";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LocalDB data = formatter.Deserialize(stream) as LocalDB;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
