using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData (HighScoreMng highScore)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/HighScore.gg";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData();
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData loadGameData()
    {
        string path = Application.persistentDataPath + "/HighScore.gg";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        } else
        {
            Debug.LogError("Save file not found in: " + path);
            return null;
        }
    }
}
