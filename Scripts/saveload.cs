using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class saveload : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     //  Save();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load()
    {
        

        //
    }
    public void Save() 
    {
        
        
        string savefile = JsonUtility.ToJson(SinaManager.Instance);
        Debug.Log(Application.dataPath);
        File.WriteAllText(Application.dataPath + "/Sina.si", savefile);

    }              
}
