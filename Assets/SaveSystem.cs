using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    //private static string path = Application.persistentDataPath + "/player.dat";
    // Saving a game progress
    public static void SavePlayer(Player player) 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.dat";
        FileStream stream = new FileStream(path, FileMode.Create); // Create and open the newly created file

        PlayerData data = new PlayerData(player); // Stores all the player data

        formatter.Serialize(stream, data);
        stream.Close(); // Close the file
        Debug.Log("Game saved to: " + path);
    }

    // Loading a saved player progress
    public static PlayerData LoadPlayer() 
    {
        string path = Application.persistentDataPath + "/player.dat";
        if (File.Exists(path)) 
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open); // Open the saved file

            PlayerData data = formatter.Deserialize(stream) as PlayerData; // Store the data from the file as a type PlayerData
            stream.Close();
            Debug.Log("Previous saved game loaded from: " + path);
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
