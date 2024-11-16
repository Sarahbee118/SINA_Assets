using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class saveManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static void fileSaving()
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "saves";
    }
}
