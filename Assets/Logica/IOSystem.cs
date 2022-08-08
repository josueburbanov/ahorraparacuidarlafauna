using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class IOSystem
{
    public static void SaveJuego(Juego juego)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game.dnrs";
        FileStream stream = File.Create(path);

        formatter.Serialize(stream, juego);
        stream.Close();
    }

    public static Juego LoadJuego()
    {
        string path = Application.persistentDataPath + "/game.dnrs";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = File.Open(path, FileMode.Open);

            Juego juego = formatter.Deserialize(stream) as Juego;
            stream.Close();
            return juego;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    


}
